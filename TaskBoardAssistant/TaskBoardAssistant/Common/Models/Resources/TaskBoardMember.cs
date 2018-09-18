using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public abstract class TaskBoardMember : ITaskResource
    {
        public abstract string Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Username { get; set; }
        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
