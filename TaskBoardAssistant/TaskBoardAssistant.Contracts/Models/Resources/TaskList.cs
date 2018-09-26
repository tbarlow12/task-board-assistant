using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models.Resources
{
    public abstract class TaskList : ITaskResource
    {
        public abstract string Id { get; }
        public abstract string Name { get; set; }
        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            var nameFilter = (filter.Name == null ||
                filter.Name.ToLower().Equals(Name.ToLower()));
            return nameFilter;
        }
        public abstract IEnumerable<TaskCard> Cards { get; }
        public abstract Task<TaskCard> CreateCard(BaseAction action);
        public abstract void SortList(BaseAction action);
    }
}
