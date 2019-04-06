using System;
using System.Collections.Generic;
using System.Text;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.AzDO.Models
{
    public class AzDOQuery
    {
        public AzDOQuery(Dictionary<string, string> queryParams)
        {
            ProjectName = queryParams.GetValueOrDefault("projectName");
            QueryName = queryParams.GetValueOrDefault("queryName");
            bool createQuery;
            bool.TryParse(queryParams.GetValueOrDefault("createQuery"), out createQuery);
            CreateQuery = createQuery;
            Guid queryId;
            Guid.TryParse(queryParams.GetValueOrDefault("queryId"), out queryId);
            QueryId = queryId;
            WorkItemType = queryParams.GetEnum<AzDOType>("workItemType");
            QueryName = queryParams.GetValueOrDefault("queryName");
            QueryName = queryParams.GetValueOrDefault("queryName");
            QueryName = queryParams.GetValueOrDefault("queryName");
            QueryName = queryParams.GetValueOrDefault("queryName");

        }
        public string ProjectName { get; private set; }
        public string QueryName { get; private set; }
        public bool CreateQuery { get; private set; }
        public Guid? QueryId { get; private set; }
        public AzDOType? WorkItemType { get; private set; }
        public int? WorkItemId { get; private set; }
        public string Title { get; private set; }
        public string AssignedTo { get; private set; }
        public AzDOState? State { get; private set; }

    }
}
