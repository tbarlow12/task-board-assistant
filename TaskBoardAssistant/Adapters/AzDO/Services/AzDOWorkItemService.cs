using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.AzDO.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public sealed class AzDOWorkItemService : CardService
    {
        private AzDOService service;
        private static readonly Lazy<AzDOWorkItemService> lazy = new Lazy<AzDOWorkItemService>(() => new AzDOWorkItemService());
        public static AzDOWorkItemService Instance { get => lazy.Value; }

        private AzDOWorkItemService()
        {
            service = AzDOService.Instance;
        }

        private string defaultQueryFolder = "My Queries";

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
                        return await service.Client.GetWorkItemsAsync(workItemRefs.Select(wir => wir.Id));
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
                return await service.Client.QueryByIdAsync(queryItem.Id);
            }
            else
            {
                return await service.Client.QueryByWiqlAsync(new Wiql()
                {
                    Query = GetWiql(query)
                });
            }
        }

        private async Task<QueryHierarchyItem> GetOrCreateQuery(AzDOQuery query, bool failIfExists = false, bool updateIfExists = false)
        {
            List<QueryHierarchyItem> queryHierarchyItems = await service.Client.GetQueriesAsync(query.ProjectName, depth: 2);
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
                    queryItem = await service.Client.CreateQueryAsync(queryItem, query.ProjectName, myQueriesFolder.Name);
                }
                else if (failIfExists)
                {
                    throw new Exception($"Query with name '{query.QueryName}' already exists");
                }
                else if (updateIfExists)
                {
                    queryItem = await service.Client.UpdateQueryAsync(queryItem, query.ProjectName, myQueriesFolder.Name);
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

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null, Dictionary<string, string> query = null)
        {
            throw new NotImplementedException();
        }

        public override Task CommitResources()
        {
            throw new NotImplementedException();
        }

        public override Task<ITaskResource> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
