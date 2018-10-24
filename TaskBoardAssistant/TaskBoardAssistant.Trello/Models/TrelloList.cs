using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Common.Services;

namespace TaskBoardAssistant.Trello.Models
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

        public async Task CreateCard(BaseAction action)
        {
            var name = action.Params.GetValueOrDefault("name");
            var desc = action.Params.GetValueOrDefault("desc");
            var due = action.Params.GetValueOrDefault("due");
            var dueDate = due.ToDateTime();
            if (dueDate == null)
                dueDate = due.ToRelativeDateTime();
            var member = action.Params.GetValueOrDefault("members");
            await List.Cards.Add(name, description:desc, dueDate:dueDate);
        }

        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            if (filter.Name != null && !Name.ToLower().Equals(filter.Name.ToLower()))
                return false;
            if (filter.Archived != null && !(bool)filter.Archived == Archived)
                return false;
            return true;
        }

        public void SortList(BaseAction action)
        {
            var cards = Cards;
        }
        /*
public override string Id => List.Id;
public override string Name { get => List.Name; set => List.Name = value; }
public override IEnumerable<TaskCard> Cards => GetCards().Result;

public override async Task<TaskCard> CreateCard(BaseAction action)
{
   await List.Cards.Add(
       action.Params["name"],
       description: action.Params.GetValueOrDefault("desc", null),
       position: new Position(0)
   );
   await List.Cards.Refresh();
   return new TrelloCard(List.Cards[0]);
}

public override void SortList(BaseAction action)
{
   throw new NotImplementedException();
}

private async Task<IEnumerable<TaskCard>> GetCards()
{
   await List.Cards.Refresh();
   var result = new List<TaskCard>();
   foreach(var card in List.Cards)
   {
       result.Add(new TrelloCard(card));
   }
   return result;
}
*/
    }
}
