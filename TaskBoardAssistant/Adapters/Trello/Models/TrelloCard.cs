using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    public class TrelloCard : ITaskCard
    {
        public TrelloCard(ICard card)
        {
            Card = card;
        }
        public ICard Card { get; private set; }
        public string Description
        {
            get => Card.Description;
            set => Card.Description = value;
        }
        public DateTime? DueDate
        {
            get => Card.DueDate;
            set => Card.DueDate = value;
        }

        public IEnumerable<ITaskLabel> Labels => GetLabels().Result;

        // PRIVATE HELPERS
        private async Task<IEnumerable<ITaskLabel>> GetLabels()
        {
            await Card.Labels.Refresh();
            var result = new List<ITaskLabel>();
            foreach (var label in Card.Labels)
            {
                result.Add(new TrelloLabel(label));
            }
            return result;
        }

        public IEnumerable<string> Comments => GetComments().Result;

        private async Task<IEnumerable<string>> GetComments()
        {
            throw new NotImplementedException();
        }

        public string Id => Card.Id;

        public string Name
        {
            get => Card.Name;
            set => Card.Name = value;
        }

        public void AddComment(string comment)
        {
            Card.Comments.Add(comment);
        }

        public void AddLabel(ITaskLabel label)
        {
            Card.Labels.Add(((TrelloLabel)label).Label);
        }

        public bool IsArchived { get => (bool) Card.IsArchived; set => Card.IsArchived = value; }

        public void Archive()
        {
            Card.IsArchived = true;
        }

        public void MoveTo(ITaskList list)
        {
            Card.List = ((TrelloList)list).List;
        }

        public void Unarchive()
        {
            Card.IsArchived = false;
        }

        public void SetPosition(int i)
        {
            Card.Position = i;
        }

        public void Rename(string newName)
        {
            Card.Name = newName;
        }
    }
}
