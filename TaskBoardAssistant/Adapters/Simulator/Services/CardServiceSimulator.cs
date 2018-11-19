using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class CardServiceSimulator : CardService
    {
        private DataRepo data;
        public CardServiceSimulator(FactorySimulator factory)
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
            IEnumerable<ITaskCard> result;
            if(parents == null)
            {
                result = data.GetAllCards();
            }
            else
            {
                result = ((IEnumerable<ITaskList>)parents).CardsInLists();
            }
            return Task.FromResult(result as IEnumerable<ITaskResource>);
        }
    }
}
