using System.Collections.Generic;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskBoard : ITaskResource
    {
        // PROPERTIES
        IEnumerable<ITaskList> Lists { get; }
        IEnumerable<ITaskBoardMember> Members { get; }
        bool IsOpen { get; set; }

        //OPERATIONS
        void Close();
        void Open();
    }
}
