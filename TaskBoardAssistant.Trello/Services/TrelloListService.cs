using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Services;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Trello.Models;
using TaskBoardAssistant.Trello.Services;
using TaskBoardAssistant.Services;

namespace TaskBoardAssistant.Trello.Services
{
    public class TrelloListService : ListService
    {
        TrelloService trello;

        public TrelloListService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trello = TrelloService.Instance;
        }

        public override Task CommitResources()
        {
            return trello.CommitResources();
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            var list = trello.Factory.List(id);
            await list.Refresh();
            return new TrelloList(list);
        }

        public async override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources)
        {
            if(parentResources == null)
            {
                var me = await trello.GetMe();
                var lists = await me.GetAllMyLists();
                return lists.ToTrelloLists();
            }
            else
            {
                var result = new List<TrelloList>();
                foreach(var parent in parentResources)
                {
                    var lists = await ((TrelloBoard)parent).Board.GetBoardLists();
                    result.AddRange(lists.ToTrelloLists());
                }
                return result;
            }
        }
    }
}
