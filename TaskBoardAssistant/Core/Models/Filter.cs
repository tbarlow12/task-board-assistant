using System;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Core.Models
{
    public class TaskBoardResourceFilter
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool? Archived { get; set; }
        public bool? Open { get; set; }
        public string DueBefore { get; set; }
        public string DueAfter { get; set; }
        public override bool Equals(Object o)
        {
            var other = (TaskBoardResourceFilter)o;
            return
                Name.NullCheckEquals(other.Name) &&
                Id.NullCheckEquals(other.Id) &&
                Archived.NullCheckEquals(other.Archived) &&
                Open.NullCheckEquals(other.Open) &&
                DueBefore.NullCheckEquals(other.DueBefore) &&
                DueAfter.NullCheckEquals(other.DueAfter);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
