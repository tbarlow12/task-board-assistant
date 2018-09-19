using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;
using TaskBoardAssistant.Adapters.Trello.Services;
using Manatee.Trello;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    class TrelloCard : TaskCard
    {
        public TrelloCard(ICard card)
        {
            Card = card;
        }
        public ICard Card { get; private set; }
        
        // PROPERTIES
        public override string Id => Card.Id; 
        public override string Name { get => Card.Name; set => Card.Name = value; }
        public override IEnumerable<TaskLabel> Labels => GetLabels().Result;
        public override string Description { get => Card.Description; set => Card.Description = value; }
        public override DateTime? DueDate { get => Card.DueDate; set => Card.DueDate = value; }
        public override IEnumerable<string> Comments {
            get
            {
                foreach(var comment in Card.Comments)
                {
                    yield return comment.ToString();
                }
            }
        }

        // PRIVATE HELPERS
        private async Task<IEnumerable<TaskLabel>> GetLabels()
        {
            await Card.Labels.Refresh();
            var result = new List<TaskLabel>();
            foreach(var label in Card.Labels)
            {
                result.Add(new TrelloLabel(label));
            }
            return result;
        }
        // OPERATIONS
        public override void MoveTo(TaskList list)
        {
            var trelloList = (TrelloList)list;
            Card.List = trelloList.List;
        }
        public override async void Archive()
        {
            Card.IsArchived = true;
        }

        public override void Unarchive()
        {
            Card.IsArchived = false;
        }

        public override void AddComment(string comment)
        {
            Card.Comments.Add(comment);
        }
        public override void AddLabel(TaskLabel label)
        {
            var trelloLabel = (TrelloLabel)label;
            Card.Labels.Add(trelloLabel.Label);
        }
    }
}
