using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models.Resources
{
    public interface ITaskList : ITaskResource
    {
        IEnumerable<ITaskCard> Cards { get; }
        Task CreateCard(BaseAction action);
        void SortList(BaseAction action);
    }
}
