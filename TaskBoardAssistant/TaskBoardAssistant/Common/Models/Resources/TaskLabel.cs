using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public abstract class TaskLabel : ITaskResource
    {
        public abstract string Id { get; }
        public abstract string Name { get; set; }
        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
