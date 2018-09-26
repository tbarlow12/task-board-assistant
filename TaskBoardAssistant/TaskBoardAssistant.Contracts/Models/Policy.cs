using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Services;

namespace TaskBoardAssistant.Models
{
    public class Policy
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public ResourceType Resource { get; set; }
        public List<TaskBoardResourceFilter> Filters { get; set; }
        public List<BaseAction> Actions { get; set; }
        public List<Policy> Children { get; set; }
        public override bool Equals(Object o)
        {
            var other = (Policy)o;
            var nameEquals = (Name == null && other.Name == null) ||
                (Name.Equals(other.Name));
            var resourceEquals = Resource.Equals(other.Resource);
            var filterEquals = ((Filters == null && other.Filters == null) || 
                (Filters.SequenceEqual(other.Filters)));
            var actionEquals = (Actions == null && other.Actions == null) || 
                (Actions.SequenceEqual(other.Actions));
            return nameEquals && resourceEquals && filterEquals && actionEquals;      
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum TaskBoardService
    {
        Trello
    }

    public enum ResourceType
    {
        Team,
        Board,
        List,
        Member,
        PowerUp,
        Search,
        Token,
        Webhook,
        Card,
        Label,
    }

    
}
