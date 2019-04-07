using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Trello.Services;
using TaskBoardAssistant.Adapters.Trello;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using System;

namespace TaskBoardAssistant.Adapters.Trello
{
    public class TrelloServiceFactory : ITaskBoardFactory
    {
        private static readonly Lazy<TrelloServiceFactory> lazy = new Lazy<TrelloServiceFactory>(() => new TrelloServiceFactory());
        public static TrelloServiceFactory Instance { get => lazy.Value; }
        private TrelloServiceFactory()
        {
            TrelloConfig.Initialize();
        }
        public BoardService BoardService => TrelloBoardService.Instance;

        public ListService ListService => TrelloListService.Instance;

        public CardService CardService => TrelloCardService.Instance;

        public LabelService LabelService => TrelloLabelService.Instance;        
    }
}
