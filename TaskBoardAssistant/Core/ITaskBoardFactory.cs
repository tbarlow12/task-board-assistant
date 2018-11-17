using System;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Core
{
    public interface ITaskBoardFactory
    {
        ResourceService GetResourceService(ResourceType type);
        BoardService GetBoardService();
        ListService GetListService();
        CardService GetCardService();
        LabelService GetLabelService();
    }
}
