using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskList : ITaskResource
    {
        // PROPERTIES
        IEnumerable<ITaskCard> Cards { get; }
        bool IsArchived { get; set; }

        // OPERATIONS
        Task AddCard(BaseAction action);
        Task AddCard(string name, string desc = null, string due = null, string member = null, bool is_archived=false);
        Task Archive();
        Task SortList(BaseAction action);
    }
}
