using System;

namespace TaskBoardAssistant.Core.Models
{
    public class TaskBoardResourceFilter
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool? Archived { get; set; }
        public bool? Open { get; set; }
        public override bool Equals(Object o)
        {
            var other = (TaskBoardResourceFilter)o;
            return
                ((Name == null && other.Name == null) || (Name.Equals(other.Name))) &&
                ((Id == null && other.Id == null) || (Id.Equals(other.Id))) &&
                ((Archived == null && other.Archived == null) || (Archived.Equals(other.Archived)));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
