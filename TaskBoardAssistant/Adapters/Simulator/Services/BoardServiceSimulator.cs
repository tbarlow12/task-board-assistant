using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    public class BoardServiceSimulator : BoardService
    {
        private DataRepo data;
        public BoardServiceSimulator(FactorySimulator factory)
        {
            Factory = factory;
            data = DataRepo.Instance;
        }
        public override Task CommitResources()
        {
            return Task.CompletedTask;
        }

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }


        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            return Task.FromResult(data.GetAllBoards() as IEnumerable<ITaskResource>);
        }
    }
}
