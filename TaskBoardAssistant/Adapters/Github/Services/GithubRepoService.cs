using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Github.Models;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public sealed class GithubRepoService : BoardService
    {
        GithubService github;
        GithubRestFactory restFactory;

        private static readonly Lazy<GithubRepoService> lazy = new Lazy<GithubRepoService>(() => new GithubRepoService());

        public static GithubRepoService Instance { get => lazy.Value; }

        private GithubRepoService()
        {
            github = GithubService.Instance;
            Factory = GithubServiceFactory.Instance;
            restFactory = GithubRestFactory.Instance;
        }

        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            var request = restFactory.Repos.GetAll();
            var response = await github.Client.Repository.GetAllForUser(GithubConfig.Username);
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
