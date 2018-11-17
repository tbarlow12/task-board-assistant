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

        private Task<IEnumerable<string>> GetComments()
        {
            throw new NotImplementedException();
        }

        public string Id => Card.Id;

        public string Name
        {
            get => Card.Name;
            set => Card.Name = value;
        }

        public Task AddComment(string comment)
        {
            Card.Comments.Add(comment);
            return Task.CompletedTask;
        }

        public Task AddLabel(ITaskLabel label)
        {
            Card.Labels.Add(((TrelloLabel)label).Label);
            return Task.CompletedTask;
        }

        public bool IsArchived { get => (bool) Card.IsArchived; set => Card.IsArchived = value; }
        public ITaskList List { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Archive()
        {
            Card.IsArchived = true;
            return Task.CompletedTask;
        }

        public Task MoveTo(ITaskList list)
        {
            Card.List = ((TrelloList)list).List;
            return Task.CompletedTask;
        }

        public Task Unarchive()
        {
            Card.IsArchived = false;
            return Task.CompletedTask;
        }

        public Task SetPosition(int i)
        {
            Card.Position = i;
            return Task.CompletedTask;
        }

        public Task Rename(string newName)
        {
            Card.Name = newName;
            return Task.CompletedTask;
        }
    }
}
