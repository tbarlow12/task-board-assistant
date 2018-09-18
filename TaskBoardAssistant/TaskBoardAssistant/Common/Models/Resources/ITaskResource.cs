using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public interface ITaskResource
    {
        string Id { get; set; }
        string Name { get; set; }
        object OriginalData { get; set; }
        bool SatisfiesFilter(TaskBoardResourceFilter filter);
    }
}
