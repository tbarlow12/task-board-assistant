using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Adapters.AzDO.Models;
using TaskBoardAssistant.Core.Services.Resources;
using System;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public class AzDOCardService : CardService
    {
        AzDOService github;

        private static readonly Lazy<AzDOCardService> lazy = new Lazy<AzDOCardService>();

        public static AzDOCardService Instance { get => lazy.Value; }

        private AzDOCardService()
        {
            github = AzDOService.Instance;
            Factory = AzDOServiceFactory.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources = null)
        {
            if (parentResources == null)
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
