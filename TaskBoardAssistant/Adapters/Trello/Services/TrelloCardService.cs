using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Adapters.Trello.Models;
using TaskBoardAssistant.Core.Services.Resources;
using System;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloCardService : CardService
    {
        TrelloService trello;

        private static readonly Lazy<TrelloCardService> lazy = new Lazy<TrelloCardService>();

        public static TrelloCardService Instance { get => lazy.Value; }

        private TrelloCardService()
        {
            Factory = TrelloServiceFactory.Instance;
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
                var me = await trello.GetMe();
                var cards = await me.GetAllMyCards();
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
