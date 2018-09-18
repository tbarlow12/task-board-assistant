using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Models
{
    public class TaskBoardResourceFilter
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool? Archived { get; set; }
        /*
        public string Text { get; set; }
        public double? Modified { get; set; }
        public double? Created { get; set; }
        public string DateCompare { get; set; }
        public List<string> Labels { get; set; }
        */
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
