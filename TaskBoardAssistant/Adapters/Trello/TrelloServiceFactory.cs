using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Trello.Services;
using TaskBoardAssistant.Adapters.Trello;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;

namespace TaskBoardAssistant.Adapters.Trello
{
    public class TrelloServiceFactory : ITaskBoardFactory
    {
        TrelloBoardService trelloBoardService;
        TrelloListService trelloListService;
        TrelloCardService trelloCardService;
        TrelloLabelService trelloLabelService;

        public TrelloServiceFactory()
        {
            TrelloConfig.Initialize();
        }

        public TrelloServiceFactory(string secretsPath)
        {
            TrelloConfig.Initialize(secretsPath);
        }

        public BoardService GetBoardService()
        {
            if (trelloBoardService == null)
                trelloBoardService = new TrelloBoardService(this);
            return trelloBoardService;
        }

        public ListService GetListService()
        {
            if (trelloListService == null)
                trelloListService = new TrelloListService(this);
            return trelloListService;
        }

        public CardService GetCardService()
        {
            if (trelloCardService == null)
                trelloCardService = new TrelloCardService(this);
            return trelloCardService;
        }

        public LabelService GetLabelService()
        {
            if (trelloLabelService == null)
                trelloLabelService = new TrelloLabelService(this);
            return trelloLabelService;
        }

        public ResourceService GetResourceService(ResourceType type)
        {
            throw new System.NotImplementedException();
        }
    }
}
