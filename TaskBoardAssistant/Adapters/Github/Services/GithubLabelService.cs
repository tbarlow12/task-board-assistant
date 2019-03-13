using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public class GithubLabelService : LabelService
    {
        GithubService github;

        private static readonly Lazy<GithubLabelService> lazy = new Lazy<GithubLabelService>(() => new GithubLabelService());

        public static GithubLabelService Instance { get => lazy.Value; }

        private GithubLabelService()
        {
            github = GithubService.Instance;
            Factory = GithubServiceFactory.Instance;
        }

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }
        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override Task CommitResources()
        {
            return github.CommitResources();
        }
    }
}
