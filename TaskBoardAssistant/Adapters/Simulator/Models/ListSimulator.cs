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
        public ListSimulator(string name, List<CardSimulator> cards=null)
        {
            Name = name;
            if (cards == null)
                _cards = new List<CardSimulator>();
            else
                _cards = cards;
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

        public Task AddCard(string name, string desc=null, string due=null, string member=null,
            bool is_archived=false)
        {
            // TODO 
            _cards.Add(new CardSimulator
            {
                List = this,
                Name = name,
                DueDate = due.ToDateTimeOrRelative(),
                Description = desc,
                IsArchived = is_archived,
                Position = _cards.Count
            });
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
