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
        Task Archive();
        Task SortList(BaseAction action);
    }
}
