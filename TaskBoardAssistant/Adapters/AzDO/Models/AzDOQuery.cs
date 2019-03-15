using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBoardAssistant.Adapters.AzDO.Models
{
    public class AzDOQuery
    {
        public string ProjectName { get; set; }
        public string QueryName { get; set; }
        public bool CreateQuery { get; set; }
        public Guid? QueryId { get; set; }
        public AzDOType? WorkItemType { get; set; }
        public int? WorkItemId { get; set; }
        public string Title { get; set; }
        public string AssignedTo { get; set; }
        public AzDOState? State { get; set; }

    }
}
