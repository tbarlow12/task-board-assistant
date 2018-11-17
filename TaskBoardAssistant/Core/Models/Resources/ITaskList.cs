using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskList : ITaskResource
    {
        // PROPERTIES
        IEnumerable<ITaskCard> Cards { get; }

        // OPERATIONS
        Task<IEnumerable<ITaskResource>> AddCard(BaseAction action);
        Task<IEnumerable<ITaskResource>> Archive();
        Task SortList(BaseAction action);
    }
}
