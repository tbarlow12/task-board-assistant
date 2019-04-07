using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Core.Models;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    public class BoardServiceSimulator : BoardService
    {
        private IEnumerable<ITaskResource> boards;
        public BoardServiceSimulator()
        {
            boards = new List<BoardSimulator>
            {
                new BoardSimulator
                {
                    Name = "Test Board 1",
                    IsOpen = true
                },
                new BoardSimulator
                {
                    Name = "Test Board 2",
                    IsOpen = true
                },
                new BoardSimulator
                {
                    Name = "Test Board 3",
                    IsOpen = false
                }
            };
        }
        public override Task CommitResources()
        {
            throw new NotImplementedException();
        }

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override ITaskBoard GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null, Dictionary<string, string> queryParams = null)
        {
            return Task.FromResult(boards);
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
