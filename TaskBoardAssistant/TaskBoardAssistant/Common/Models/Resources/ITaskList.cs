using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public interface ITaskList : ITaskResource
    {
        IEnumerable<ITaskCard> Cards { get; }
    }
}
