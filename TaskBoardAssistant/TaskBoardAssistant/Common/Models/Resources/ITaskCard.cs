using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models.Resources
{
    public interface ITaskCard : ITaskResource
    {
        IEnumerable<ITaskLabel> Labels { get; }
        void MoveTo(ITaskList list);
        void Archive();
    }
}
