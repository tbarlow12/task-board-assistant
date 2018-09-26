using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Common.Services;

namespace TaskBoardAssistant.Trello.Models
{
    public class TrelloList : TaskList
    {
        public TrelloList(IList list)
        {
            List = list;
        }
        public IList List { get; private set; }
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
    }
}
