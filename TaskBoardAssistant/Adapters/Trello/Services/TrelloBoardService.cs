using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Trello.Models;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloBoardService : BoardService
    {
        TrelloService trello;

        private static readonly Lazy<TrelloBoardService> lazy = new Lazy<TrelloBoardService>(() => new TrelloBoardService());

        public static TrelloBoardService Instance { get => lazy.Value; }

        private TrelloBoardService()
        {
            Factory = TrelloServiceFactory.Instance;
            trello = TrelloService.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            var board = trello.Factory.Board(id);
            await board.Refresh();
            return new TrelloBoard(board);
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null, Dictionary<string, string> queryParams = null)
        {
            if(parents != null)
            {
                throw new Exception("Boards shouldn't have parents");
            }
            var me = await trello.GetMe();
            var boards = await me.GetAllMyBoards();
            return boards.ToTrelloBoards();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override Task CommitResources()
        {
            return trello.CommitResources();
        }

        public override async Task<ITaskResource> GetByName(string name)
        {
            var boards = await GetResources();
            foreach(var board in boards)
            {
                if (board.Name.EqualsIgnoreCase(name))
                {
                    return board;
                }
            }
            return null;
        }
    }
}
