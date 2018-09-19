using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;
using TaskBoardAssistant.Common.Models;

namespace TaskBoardAssistant.Common.Services
{
    public abstract class LabelService : ResourceService
    {
        public TaskLabel GetLabel(string boardName, string labelName)
        {
            var boardService = Factory.GetBoardService();
            var board = boardService.GetByName(boardName);
            return GetLabel(board, labelName);
        }

        public TaskLabel GetLabel(TaskBoard board, string labelName)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

    }
}
