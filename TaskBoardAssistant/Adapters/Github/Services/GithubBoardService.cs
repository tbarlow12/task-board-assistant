using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Github.Models;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public sealed class GithubBoardService : BoardService
    {
        GithubService github;

        private static readonly Lazy<GithubBoardService> lazy = new Lazy<GithubBoardService>();

        public static GithubBoardService Instance { get => lazy.Value; }

        private GithubBoardService()
        {
            github = GithubService.Instance;
            Factory = GithubServiceFactory.Instance;
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
