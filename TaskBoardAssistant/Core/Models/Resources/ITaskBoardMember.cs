namespace TaskBoardAssistant.Core.Models.Resources
{
    public interface ITaskBoardMember : ITaskResource
    {
        string Username { get; }
        string FullName { get; }
    }
}
