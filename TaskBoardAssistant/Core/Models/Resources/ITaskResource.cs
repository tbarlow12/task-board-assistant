using System.Threading.Tasks;

namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskResource
    {
        // PROPERTIES
        string Id { get; }
        string Name { get; set; }

        // OPERATIONS
        Task Rename(string newName);
    }
}
