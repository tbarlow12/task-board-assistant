using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Models;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class CardServiceSimulator : CardService
    {
        List<CardSimulator> _cards;
        public CardServiceSimulator(FactorySimulator factory)
        {
            Factory = factory;
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
            
            if(parents != null)
            {
                var result = new List<ITaskResource>();
                foreach(var parent in parents)
                {
                    result.AddRange(((ListSimulator)parent).Cards);
                }
                return Task.FromResult(result as IEnumerable<ITaskResource>);
            }
            return Task.FromResult(_cards as IEnumerable<ITaskResource>);
        }
    }
}
