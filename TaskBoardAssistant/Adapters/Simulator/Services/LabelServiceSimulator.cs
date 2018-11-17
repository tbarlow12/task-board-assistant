using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Adapters.Simulators.Services
{
    class LabelServiceSimulator : LabelService
    {
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
            throw new NotImplementedException();
        }
    }
}
