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
    public class TrelloListService : ListService
    {
        IMe me;
        TrelloFactory trelloFactory;

        public TrelloListService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trelloFactory = new TrelloFactory();
            me = trelloFactory.Me().Result;
        }

        public override void CommitResources()
        {
            TrelloProcessor.Flush();
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            var list = trelloFactory.List(id);
            await list.Refresh();
            return new TrelloList(list);
        }
        public override IEnumerable<ITaskResource> GetResources(IEnumerable<ITaskResource> parentResources)
        {
            if(parentResources == null)
            {
                var lists = new TrelloFactory().Me().Result.GetAllMyLists();
                foreach(var list in lists)
                {
                    yield return new TrelloList(list);
                }
            }
            else
            {
                foreach(var parent in parentResources)
                {
                    var lists = ((TrelloBoard)parent).Board.GetBoardLists().Result;
                    foreach(var list in lists)
                    {
                        yield return new TrelloList(list);
                    }
                }
            }
        }
    }
}
