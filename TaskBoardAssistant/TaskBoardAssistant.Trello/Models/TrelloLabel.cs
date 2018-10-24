using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant.Trello.Models
{
    public class TrelloLabel : ITaskLabel
    {
        public TrelloLabel(ILabel label)
        {
            Label = label;
        }
        public ILabel Label { get; private set; }

        public string Id => Label.Id;

        public string Name { get => Label.Name; set => Label.Name = value; }

        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
