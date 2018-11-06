using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models.Resources
{
    public interface ITaskResource
    {
        string Id { get; }
        string Name { get; set; }
        bool SatisfiesFilter(TaskBoardResourceFilter filter);
    }
}
