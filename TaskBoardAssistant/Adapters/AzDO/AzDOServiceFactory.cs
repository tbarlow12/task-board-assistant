using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.AzDO.Services;
using TaskBoardAssistant.Adapters.AzDO;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using System;

namespace TaskBoardAssistant.Adapters.AzDO
{
    public class AzDOServiceFactory : ITaskBoardFactory
    {
        private static readonly Lazy<AzDOServiceFactory> lazy = new Lazy<AzDOServiceFactory>();

        public static AzDOServiceFactory Instance { get => lazy.Value; }

        private AzDOServiceFactory()
        {
            AzDOConfig.Initialize();
        }

        public BoardService BoardService => AzDOBoardService.Instance;

        public ListService ListService => AzDOListService.Instance;

        public CardService CardService => AzDOCardService.Instance;

        public LabelService LabelService => AzDOLabelService.Instance;
    }
}
