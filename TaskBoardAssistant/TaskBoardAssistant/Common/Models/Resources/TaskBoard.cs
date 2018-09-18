using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public abstract class TaskBoard : ITaskResource
    {
        public abstract string Id { get; }
        public abstract string Name { get; set; }
        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            var nameFilter = (filter.Name == null ||
                filter.Name.ToLower().Equals(Name.ToLower()));
            return nameFilter;
        }
        // PROPERTIES
        public abstract IEnumerable<TaskList> Lists { get; }
        public abstract IEnumerable<TaskBoardMember> Members { get; }
        //OPERATIONS
        public abstract void Close();
        public abstract void Open();
    }
}
