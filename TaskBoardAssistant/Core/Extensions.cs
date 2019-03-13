using System;
using System.Collections.Generic;
using System.Text;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Core
{
    public static class Extensions
    {
        public static ResourceService GetResourceService(this ITaskBoardFactory factory, ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Board:
                case ResourceType.Repo:
                    return factory.BoardService;
                case ResourceType.List:
                    return factory.ListService;
                case ResourceType.Card:
                    return factory.CardService;
                case ResourceType.Label:
                    return factory.LabelService;
                default:
                    throw new Exception("Non-supported resource type");
            }
        }
    }
}
