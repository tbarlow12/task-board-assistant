using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Models;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class LabelServiceSimulator : LabelService
    {
        List<LabelSimulator> _labels;
        public LabelServiceSimulator(FactorySimulator factory)
        {
            Factory = factory;
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
            return Task.FromResult(_labels as IEnumerable<ITaskResource>);
        }
    }
}
