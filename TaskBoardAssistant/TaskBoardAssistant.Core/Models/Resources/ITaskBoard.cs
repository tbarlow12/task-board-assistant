using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models.Resources
{
    public interface ITaskBoard : ITaskResource
    {
        // PROPERTIES
        IEnumerable<ITaskList> Lists { get; }
        IEnumerable<ITaskBoardMember> Members { get; }
        //OPERATIONS
        void Close();
        void Open();
    }
}
