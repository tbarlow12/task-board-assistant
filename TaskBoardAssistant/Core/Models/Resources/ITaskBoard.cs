using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskBoard : ITaskResource
    {
        // PROPERTIES
        IEnumerable<ITaskList> Lists { get; }
        IEnumerable<ITaskMember> Members { get; }
        bool IsOpen { get; set; }

        //OPERATIONS
        Task Close();
        Task Open();
    }
}
