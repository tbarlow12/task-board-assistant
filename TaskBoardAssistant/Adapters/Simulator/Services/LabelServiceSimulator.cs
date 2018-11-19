using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class LabelServiceSimulator : LabelService
    {
        private DataRepo data;
        public LabelServiceSimulator(FactorySimulator factory)
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
            IEnumerable<ITaskLabel> result;
            if(parents == null)
            {
                result = data.GetAllLabels();
            }
            else
            {
                result = ((IEnumerable<ITaskCard>)parents).LabelsInCards();
            }
            return Task.FromResult(result as IEnumerable<ITaskResource>);
        }
    }
}
