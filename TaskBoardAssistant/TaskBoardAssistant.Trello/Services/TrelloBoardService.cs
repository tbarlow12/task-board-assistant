using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Common.Models.Resources;
using TaskBoardAssistant.Adapters.Trello.Models;
using TaskBoardAssistant.Common.Services;
using Manatee;
using Manatee.Trello;

namespace TaskBoardAssistant.Trello.Services
{
    public class TrelloBoardService : BoardService
    {
        IMe me;
        TrelloFactory trelloFactory;

        public TrelloBoardService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trelloFactory = new TrelloFactory();
            me = trelloFactory.Me().Result;
        }

        public override IEnumerable<ITaskResource> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            if(parents != null)
            {
                throw new Exception("Boards shouldn't have parents right now");
            }
            var boards = me.GetAllMyBoards().Result;
            foreach(var board in boards)
            {
                yield return new TrelloBoard(board);
            }
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override Task CommitResources()
        {
            return TrelloProcessor.Flush();
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            var board = trelloFactory.Board(id);
            await board.Refresh();
            return new TrelloBoard(board);
        }

        public override TaskBoard GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
