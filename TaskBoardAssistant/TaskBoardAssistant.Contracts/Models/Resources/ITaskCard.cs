using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models.Resources
{
    public interface ITaskCard : ITaskResource
    {
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        IEnumerable<TaskLabel> Labels { get; }
        IEnumerable<string> Comments { get; }

        // OPERATIONS
        void MoveTo(TaskList list);
        void Archive();
        void Unarchive();
        void AddComment(string comment);
        void AddLabel(TaskLabel label);
    }
}
