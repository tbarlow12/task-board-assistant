using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant.Services
{
    public abstract class LabelService : ResourceService
    {
        public ITaskLabel GetLabel(string boardName, string labelName)
        {
            var boardService = Factory.GetBoardService();
            var board = boardService.GetByName(boardName);
            return GetLabel(board, labelName);
        }

        public ITaskLabel GetLabel(ITaskBoard board, string labelName)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

    }
}
