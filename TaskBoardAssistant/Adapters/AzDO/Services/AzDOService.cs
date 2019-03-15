
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.AzDO.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public sealed class AzDOService
    {
        private string defaultQueryFolder = "My Queries";
        private static readonly Lazy<AzDOService> lazy = new Lazy<AzDOService>(() => new AzDOService());

        public static AzDOService Instance { get => lazy.Value; }

        private WorkItemTrackingHttpClient client;

        private AzDOService()
        {
            VssConnection connection = new VssConnection(new Uri(AzDOConfig.CollectionUri), new VssBasicCredential(string.Empty, AzDOConfig.PersonalAccessToken));
            client = connection.GetClient<WorkItemTrackingHttpClient>();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItems(AzDOQuery query)
        {
            var queryResult = await GetQueryResult(query);
            if (queryResult.WorkItems.Any())
            {
                int skip = 0;
                const int batchSize = 100;
                IEnumerable<WorkItemReference> workItemRefs;
                do
                {
                    workItemRefs = queryResult.WorkItems.Skip(skip).Take(batchSize);
                    if (workItemRefs.Any())
                    {
                        return await client.GetWorkItemsAsync(workItemRefs.Select(wir => wir.Id));
                    }
                    skip += batchSize;
                }
                while (workItemRefs.Count() == batchSize);
            }
            return new List<WorkItem>();
        }

        private async Task<WorkItemQueryResult> GetQueryResult(AzDOQuery query)
        {
            if (query.CreateQuery || query.QueryName != null || query.QueryId != null)
            {
                var queryItem = await this.GetOrCreateQuery(query);
                return await client.QueryByIdAsync(queryItem.Id);
            }
            else
            {
                return await client.QueryByWiqlAsync(new Wiql()
                {
                    Query = GetWiql(query)
                });
            }
        }

        private async Task<QueryHierarchyItem> GetOrCreateQuery(AzDOQuery query, bool failIfExists = false, bool updateIfExists = false)
        {
            List<QueryHierarchyItem> queryHierarchyItems = await client.GetQueriesAsync(query.ProjectName, depth: 2);
            QueryHierarchyItem myQueriesFolder = queryHierarchyItems.FirstOrDefault(qhi => qhi.Name.Equals(this.defaultQueryFolder));
            if (myQueriesFolder != null)
            {
                QueryHierarchyItem queryItem = null;
                if (myQueriesFolder.Children != null)
                {
                    queryItem = myQueriesFolder.Children.FirstOrDefault(qhi => qhi.Name.Equals(query.QueryName));
                }
                if (queryItem == null)
                {
                    queryItem = new QueryHierarchyItem
                    {
                        Name = query.QueryName,
                        Wiql = this.GetWiql(query),
                        IsFolder = false
                    };
                    queryItem = await client.CreateQueryAsync(queryItem, query.ProjectName, myQueriesFolder.Name);
                }
                else if (failIfExists)
                {
                    throw new Exception($"Query with name '{query.QueryName}' already exists");
                }
                else if (updateIfExists)
                {
                    queryItem = await client.UpdateQueryAsync(queryItem, query.ProjectName, myQueriesFolder.Name);
                }
                return queryItem;
            }
            else
            {
                throw new Exception("Folder 'My Queries' is null");
            }
        }

        private string GetWiql(AzDOQuery query)
        {
            string wiql = "SELECT [System.Id],[System.WorkItemType],[System.Title],[System.AssignedTo],[System.State],[System.Tags] " +
                $"FROM WorkItems WHERE [System.TeamProject] = @project ";
            if (query.WorkItemId != null)
            {
                wiql += $"AND [System.Id] = '{query.WorkItemId}' ";
            }
            if (query.WorkItemType != null)
            {
                wiql += $"AND [System.WorkItemType] = '{query.WorkItemType}' ";
            }
            if (query.Title != null)
            {
                wiql += $"AND [System.Title] = {query.Title} ";
            }
            if (query.AssignedTo != null)
            {
                wiql += $"AND [System.AssignedTo] = {query.AssignedTo} ";
            }
            if (query.State != null)
            {
                wiql += $"AND [System.State] = {query.State} ";
            }
            return wiql;
        }

        public Task CommitResources()
        {
            throw new NotImplementedException();
        }
    }
}
