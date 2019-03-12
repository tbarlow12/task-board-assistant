using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Github.Services;
using TaskBoardAssistant.Adapters.Github;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using System;

namespace TaskBoardAssistant.Adapters.Github
{
    public class GithubServiceFactory : ITaskBoardFactory
    {
        private static readonly Lazy<GithubServiceFactory> lazy = new Lazy<GithubServiceFactory>();

        public static GithubServiceFactory Instance { get => lazy.Value; }

        private GithubServiceFactory()
        {
            GithubConfig.Initialize();
        }

        public BoardService BoardService => GithubBoardService.Instance;

        public ListService ListService => GithubListService.Instance;

        public CardService CardService => GithubCardService.Instance;

        public LabelService LabelService => GithubLabelService.Instance;
    }
}
