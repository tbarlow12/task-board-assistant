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
        Task MoveTo(ITaskList list);
        Task Archive();
        Task Unarchive();
        Task AddComment(string comment);
        Task AddLabel(ITaskLabel label);
        Task SetPosition(int i);
    }
}
