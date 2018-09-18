using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public abstract class TaskCard : ITaskResource
    {
        public abstract string Id { get; }
        public abstract string Name { get; set; }
        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            throw new NotImplementedException();
        }
        public abstract string Description { get; set; }
        public abstract DateTime? DueDate { get; set; }
        public abstract IEnumerable<TaskLabel> Labels { get; }
        public abstract IEnumerable<string> Comments { get; }

        // OPERATIONS
        public abstract void MoveTo(TaskList list);
        public abstract void Archive();
        public abstract void Unarchive();
        public abstract void AddComment(string comment);
        public abstract void AddLabel(TaskLabel label);
    }
}
