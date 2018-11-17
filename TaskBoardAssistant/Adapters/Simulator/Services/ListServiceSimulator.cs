using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Models;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class ListServiceSimulator : ListService
    {
        private List<ListSimulator> lists;
        public ListServiceSimulator(FactorySimulator factory)
        {
            Factory = factory;
            lists = new List<ListSimulator>
            {
                new ListSimulator("To Doing"),
                new ListSimulator("Doing"),
                new ListSimulator("Done")
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

        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            return Task.FromResult(lists as IEnumerable<ITaskResource>);
        }
    }
}
