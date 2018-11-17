using Manatee.Trello;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    public class TrelloList : ITaskList
    {
        public TrelloList(IList list)
        {
            List = list;
        }
        public IList List { get; private set; }

        public IEnumerable<ITaskCard> Cards => GetCards().Result;


        public async Task<IEnumerable<ITaskCard>> GetCards()
        {
            await List.Cards.Refresh();
            var result = new List<ITaskCard>();
            foreach(var card in List.Cards)
            {
                result.Add(new TrelloCard(card));
            }
            return result;
        }
        public string Id => List.Id;

        public string Name { get => List.Name; set => List.Name = value; }

        public bool Archived { get => (bool)List.IsArchived; set => List.IsArchived = value; }

        public async Task AddCard(BaseAction action)
        {
            var name = action.Params.GetValueOrDefault("name");
            var desc = action.Params.GetValueOrDefault("desc");
            var due = action.Params.GetValueOrDefault("due");
            var member = action.Params.GetValueOrDefault("members");
            await AddCard(name, desc, due, member);
        }

        public async Task AddCard(string name, string desc = null, string due = null, string member = null)
        {
            var dueDate = due.ToDateTime();
            if (dueDate == null)
                dueDate = due.ToRelativeDateTime();
            await List.Cards.Add(name, description: desc, dueDate: dueDate);
        }

        public Task SortList(BaseAction action)
        {
            var cards = Cards;
            return Task.CompletedTask;
        }

        Task<IEnumerable<ITaskResource>> ITaskList.AddCard(BaseAction action)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ITaskResource>> Archive()
        {
            throw new System.NotImplementedException();
        }

        public Task Rename(string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}
