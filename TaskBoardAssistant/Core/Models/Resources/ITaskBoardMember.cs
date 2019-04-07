namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskMember : ITaskResource
    {
        string Username { get; }
        string FullName { get; }
    }
}
