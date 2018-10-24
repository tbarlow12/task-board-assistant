using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Models
{
    public class PolicyCollection
    {
        public ServiceProvider Provider { get; set; }
        public List<Policy> Policies { get; set; }
    }

    public enum ServiceProvider
    {
        Trello,
        Jira,
        Planner
    }
}
