using System.Collections.Generic;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Core.Models
{
    public class PolicyResult
    {
        public IEnumerable<ITaskResource> ResourcesBeforeFilters { get; set; }
        public IEnumerable<ITaskResource> ResourcesBeforeActions { get; set; }
        public IEnumerable<ITaskResource> ResourcesAfterActions { get; set; }
        public List<PolicyResult> ChildrenResults { get; set; }
    }
}
