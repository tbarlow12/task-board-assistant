using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models
{
    class PolicyCollection
    {
        public Service Service { get; set; }
        public List<Policy> Policies { get; set; }
    }

    public enum Service
    {
        Trello,
        Jira,
        Planner
    }
}
