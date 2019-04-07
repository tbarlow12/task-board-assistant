using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskList : ITaskResource
    {
        // PROPERTIES
        IEnumerable<ITaskCard> Cards { get; }

        // OPERATIONS
        Task<ITaskResource> AddCard(BaseAction action);
        Task Archive();
        Task SortList(BaseAction action);
    }
}
