using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Github.Models;
using System;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public class GithubListService : ListService
    {
        GithubService github;

        private static readonly Lazy<GithubListService> lazy = new Lazy<GithubListService>(() => new GithubListService());

        public static GithubListService Instance { get => lazy.Value; }

        private GithubListService()
        {
            github = GithubService.Instance;
            Factory = GithubServiceFactory.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parentResources, Dictionary<string, string> queryParams = null)
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
