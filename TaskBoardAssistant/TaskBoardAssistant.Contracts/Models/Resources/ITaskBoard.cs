using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models.Resources
{
    public interface ITaskBoard : ITaskResource
    {
        string Id { get; }
        string Name { get; set; }
        bool SatisfiesFilter(TaskBoardResourceFilter filter);

        // PROPERTIES
        IEnumerable<TaskList> Lists { get; }
        IEnumerable<TaskBoardMember> Members { get; }
        //OPERATIONS
        void Close();
        void Open();
    }
}
