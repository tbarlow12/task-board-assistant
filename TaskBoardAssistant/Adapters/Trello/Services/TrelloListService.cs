using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Trello.Models;
using System;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloListService : ListService
    {
        TrelloService trello;

        private static readonly Lazy<TrelloListService> lazy = new Lazy<TrelloListService>(() => new TrelloListService());

        public static TrelloListService Instance { get => lazy.Value; }

        private TrelloListService()
        {
            Factory = TrelloServiceFactory.Instance;
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

        public async override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources, Dictionary<string, string> queryParams = null)
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
