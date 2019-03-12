
using System;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public sealed class GithubService
    {
        private static readonly Lazy<GithubService> lazy = new Lazy<GithubService>(() => new GithubService());

        public static GithubService Instance { get => lazy.Value; }

        private GithubService() { }

        public object Factory
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task CommitResources()
        {
            throw new NotImplementedException();
        }
    }
}
