using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.AzDO.Models;
using System;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public class AzDOListService : ListService
    {
        AzDOService github;

        private static readonly Lazy<AzDOListService> lazy = new Lazy<AzDOListService>();

        public static AzDOListService Instance { get => lazy.Value; }

        private AzDOListService()
        {
            github = AzDOService.Instance;
            Factory = AzDOServiceFactory.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources)
        {
            if(parentResources == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override Task CommitResources()
        {
            return github.CommitResources();
        }
    }
}
