using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskCard : ITaskResource
    {
        // PROPERTIES
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        IEnumerable<ITaskLabel> Labels { get; }
        IEnumerable<string> Comments { get; }
        bool IsArchived { get; set; }

        // OPERATIONS
        void MoveTo(ITaskList list);
        void Archive();
        void Unarchive();
        void AddComment(string comment);
        void AddLabel(ITaskLabel label);
        void SetPosition(int i);
    }
}
