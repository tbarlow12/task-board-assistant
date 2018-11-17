using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Simulators.Models
{
    class ListSimulator : ResourceSimulator, ITaskList
    {
        private List<CardSimulator> _cards;

        public ListSimulator(string name)
        {
            Name = name;
            _cards = new List<CardSimulator>
            {
                new CardSimulator(this, "Test Card 1"),
                new CardSimulator(this, "Test Card 2"),
                new CardSimulator(this, "Test Card 3"),
                new CardSimulator(this, "Test Card 4")
            };
        }
        public IEnumerable<ITaskCard> Cards { get => _cards; set => _cards = value as List<CardSimulator>; }
        public bool IsArchived { get; set; }

        public async Task AddCard(BaseAction action)
        {
            var name = action.Params.GetValueOrDefault("name");
            var desc = action.Params.GetValueOrDefault("desc");
            var due = action.Params.GetValueOrDefault("due");
            var member = action.Params.GetValueOrDefault("members");
            await AddCard(name, desc, due, member);
        }

        private Task AddCard(string name, string desc, string due, string member)
        {
            _cards.Add(new CardSimulator(name, desc, due, member));
            return Task.CompletedTask;
        }

        public Task Archive()
        {
            IsArchived = true;
            return Task.CompletedTask;
        }

        public Task SortList(BaseAction action)
        {
            throw new System.NotImplementedException();
        }
    }
}
