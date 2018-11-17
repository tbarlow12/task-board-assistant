using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Models;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    public class BoardServiceSimulator : BoardService
    {
        private IEnumerable<BoardSimulator> boards;
        public BoardServiceSimulator(FactorySimulator factory)
        {
            Factory = factory;
            boards = new List<BoardSimulator>
            {
                new BoardSimulator("Personal"),
                new BoardSimulator("Work"),
                new BoardSimulator("Project")
            };
            foreach(var board in boards)
            {
                board.Lists = new List<ListSimulator>
                {
                    new ListSimulator("To Doing"),
                    new ListSimulator("Doing"),
                    new ListSimulator("Done")
                };
                foreach(var list in board.Lists)
                {
                    ((ListSimulator)list).Cards = new List<CardSimulator>
                    {
                        new CardSimulator(list, "Test Card 1"),
                        new CardSimulator(list, "Test Card 2"),
                        new CardSimulator(list, "Test Card 3"),
                        new CardSimulator(list, "Test Card 4")
                    };
                }
            }
        }
        public override Task CommitResources()
        {
            return Task.CompletedTask;
        }

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override ITaskBoard GetByName(string name)
        {
            foreach(var board in boards)
            {
                if (board.Name.ToLower().Equals(name.ToLower()))
                {
                    return board;
                }
            }
            return null;
        }

        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            return Task.FromResult(boards as IEnumerable<ITaskResource>);
        }
    }
}
