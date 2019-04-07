
using RestSharp;
using System;
using System.Threading.Tasks;
using Octokit;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public sealed class GithubService
    {
        private static readonly Lazy<GithubService> lazy = new Lazy<GithubService>(() => new GithubService());

        public static GithubService Instance { get => lazy.Value; }

        private GithubService() { }

        public GitHubClient Client {
            get
            {
                var client = new GitHubClient(new ProductHeaderValue(GithubConfig.Username));
                client.Credentials = new Credentials(GithubConfig.Token);
                return client;
            }
        }

        public Task CommitResources()
        {
            throw new NotImplementedException();
        }
    }
}
