using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Services;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Trello.Models;
using TaskBoardAssistant.Trello.Services;

namespace TaskBoardAssistant.Trello.Services
{
    public class TrelloCardService : CardService
    {
        TrelloService trello;

        public TrelloCardService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trello = TrelloService.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            var card = trello.Factory.Card(id);
            await card.Refresh();
            return new TrelloCard(card);
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources = null)
        {
            if (parentResources == null)
            {
                var cards = await trello.Me.GetAllMyCards();
                return cards.ToTrelloCards();
            }
            else
            {
                var result = new List<TrelloCard>();
                foreach(var parent in parentResources)
                {
                    var cards = await ((TrelloList)parent).List.GetListCards();
                    result.AddRange(cards.ToTrelloCards());
                }
                return result;
            }
        }

        public override Task CommitResources()
        {
            return trello.CommitResources();
        }
    }
}
