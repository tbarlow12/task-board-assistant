using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;

namespace TaskBoardAssistant.Common.Models
{
    public class PolicyResult
    {
        public IEnumerable<ITaskResource> ResourcesBeforeFilters { get; set; }
        public IEnumerable<ITaskResource> ResourcesBeforeActions { get; set; }
        public IEnumerable<ITaskResource> ResourcesAfterActions { get; set; }
        public List<PolicyResult> ChildrenResults { get; set; }
    }
}
