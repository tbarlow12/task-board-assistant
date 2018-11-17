using Manatee.Trello;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Trello.Models
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

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}
