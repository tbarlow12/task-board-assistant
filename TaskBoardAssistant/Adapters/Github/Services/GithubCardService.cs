using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Adapters.Github.Models;
using TaskBoardAssistant.Core.Services.Resources;
using System;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public class GithubCardService : CardService
    {
        GithubService github;

        private static readonly Lazy<GithubCardService> lazy = new Lazy<GithubCardService>(() => new GithubCardService());

        public static GithubCardService Instance { get => lazy.Value; }

        private GithubCardService()
        {
            github = GithubService.Instance;
            Factory = GithubServiceFactory.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources = null, Dictionary<string, string> queryParams = null)
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
