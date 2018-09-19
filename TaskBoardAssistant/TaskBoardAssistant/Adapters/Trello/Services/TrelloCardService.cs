using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Services;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Common.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Adapters.Trello.Models;
using TaskBoardAssistant.Adapters.Trello.Services;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloCardService : CardService
    {
        IMe me;
        TrelloFactory trelloFactory;

        public TrelloCardService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trelloFactory = new TrelloFactory();
            me = trelloFactory.Me().Result;
        }

        public override async void CommitResources()
        {
            await TrelloProcessor.Flush();
        }
        public async override Task<ITaskResource> GetById(string id)
        {
            var card = trelloFactory.Card(id);
            await card.Refresh();
            return new TrelloCard(new Card(id));
        }
        public override IEnumerable<ITaskResource> GetResources(IEnumerable<ITaskResource> parentResources = null)
        {
            if(parentResources == null)
            {
                var me = new TrelloFactory().Me().Result;
                foreach (var card in me.GetAllMyCards())
                {
                    yield return new TrelloCard(card);
                }
            }
            else
            {
                foreach(var parent in parentResources)
                {
                    var cards = ((TrelloList)parent).List.GetListCards().Result;
                    foreach (var card in cards)
                    {
                        yield return new TrelloCard(card);
                    }
                }
            }
        }
    }
}
