using System.Collections.Generic;

namespace TaskBoardAssistant.Core.Models
{
    public class PolicyCollection
    {
        public ServiceProvider Provider { get; set; }
        public List<Policy> Policies { get; set; }
    }

    public enum ServiceProvider
    {
        Simulator,
        Trello,
        Jira,
        Planner
    }
}
