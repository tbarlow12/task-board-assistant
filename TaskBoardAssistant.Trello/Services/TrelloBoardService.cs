using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Trello.Models;
using TaskBoardAssistant.Services;
using Manatee;
using Manatee.Trello;

namespace TaskBoardAssistant.Trello.Services
{
    public class TrelloBoardService : BoardService
    {
        TrelloService trello;

        public TrelloBoardService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trello = TrelloService.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            var board = trello.Factory.Board(id);
            await board.Refresh();
            return new TrelloBoard(board);
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            if(parents != null)
            {
                throw new Exception("Boards shouldn't have parents right now");
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

        public override ITaskBoard GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
