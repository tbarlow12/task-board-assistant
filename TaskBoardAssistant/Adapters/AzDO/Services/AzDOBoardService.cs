using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.AzDO.Models;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public sealed class AzDOBoardService : BoardService
    {
        AzDOService github;

        private static readonly Lazy<AzDOBoardService> lazy = new Lazy<AzDOBoardService>(() => new AzDOBoardService());

        public static AzDOBoardService Instance { get => lazy.Value; }

        private AzDOBoardService()
        {
            github = AzDOService.Instance;
            Factory = AzDOServiceFactory.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override ITaskBoard GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override Task CommitResources()
        {
            return github.CommitResources();
        }
    }
}
