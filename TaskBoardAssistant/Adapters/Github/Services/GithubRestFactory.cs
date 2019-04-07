using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBoardAssistant.Adapters.Github.Services
{
    public sealed class GithubRestFactory
    {
        private static readonly Lazy<GithubRestFactory> lazy = new Lazy<GithubRestFactory>(() => new GithubRestFactory());
        public static GithubRestFactory Instance { get => lazy.Value; }
        private GithubRestFactory() { }
        public GithubRepoRestFactory Repos { get => GithubRepoRestFactory.Instance; }
    }

    public sealed class GithubRepoRestFactory
    {
        private static readonly Lazy<GithubRepoRestFactory> lazy = new Lazy<GithubRepoRestFactory>(() => new GithubRepoRestFactory());
        public static GithubRepoRestFactory Instance { get => lazy.Value; }
        private GithubRepoRestFactory() { }
        public RestRequest GetAll()
        {
            var request = new RestRequest("{user}/repos", Method.GET);
            request.AddUrlSegment("user", GithubConfig.Username);
            AddHeaders(request);
            return request;
        }

        private void AddHeaders(RestRequest request)
        {
            request.AddHeader("token", GithubConfig.Token);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
        }
    }
}
