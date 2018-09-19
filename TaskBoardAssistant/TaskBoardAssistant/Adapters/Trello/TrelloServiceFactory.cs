using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant;
using TaskBoardAssistant.Common;
using TaskBoardAssistant.Adapters.Trello.Services;
using Manatee.Trello;
using TaskBoardAssistant.Common.Services;

namespace TaskBoardAssistant.Adapters.Trello
{
    public class TrelloServiceFactory : TaskBoardFactory
    {
        TrelloBoardService trelloBoardService;
        TrelloListService trelloListService;
        TrelloCardService trelloCardService;
        TrelloLabelService trelloLabelService;

        public TrelloServiceFactory(string secretsPath)
        {
            TrelloConfig.Initialize(secretsPath);
        }

        public override BoardService GetBoardService()
        {
            if (trelloBoardService == null)
                trelloBoardService = new TrelloBoardService(this);
            return trelloBoardService;
        }

        public override ListService GetListService()
        {
            if (trelloListService == null)
                trelloListService = new TrelloListService(this);
            return trelloListService;
        }

        public override CardService GetCardService()
        {
            if (trelloCardService == null)
                trelloCardService = new TrelloCardService(this);
            return trelloCardService;
        }

        public override LabelService GetLabelService()
        {
            if (trelloLabelService == null)
                trelloLabelService = new TrelloLabelService(this);
            return trelloLabelService;
        }
    }
}
