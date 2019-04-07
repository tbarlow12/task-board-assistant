using System;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Core
{
    public interface ITaskBoardFactory
    {
        BoardService BoardService { get; }
        ListService ListService { get; }
        CardService CardService { get; }
        LabelService LabelService { get; }
    }
}
