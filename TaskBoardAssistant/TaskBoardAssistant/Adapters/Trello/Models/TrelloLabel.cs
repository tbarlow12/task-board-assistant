using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;
using Manatee.Trello;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    class TrelloLabel : TaskLabel
    {
        public TrelloLabel(ILabel label)
        {
            Label = label;
        }
        public ILabel Label { get; private set; }
        public override string Id => Label.Id;
        public override string Name { get => Label.Name; set => Label.Name = value; }
    }
}
