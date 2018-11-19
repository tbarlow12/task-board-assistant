using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class ListServiceSimulator : ListService
    {
        private DataRepo data;
        public ListServiceSimulator(FactorySimulator factory)
        {
            Factory = factory;
            data = DataRepo.Instance;
        }
        public override Task CommitResources()
        {
            throw new NotImplementedException();
        }

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            IEnumerable<ITaskList> result;
            if(parents == null)
            {
                result = data.GetAllLists();
            }
            else
            {
                result = ((IEnumerable<ITaskBoard>)parents).ListsInBoards();
            }
            return Task.FromResult(result as IEnumerable<ITaskResource>);
        }
    }
}
