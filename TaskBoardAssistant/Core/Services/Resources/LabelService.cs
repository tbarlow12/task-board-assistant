using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Core.Services.Resources
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

        public override bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter)
        {
            return filter.Name.IsNullOrEqualsIgnoreCase(resource.Name);
        }

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

    }
}
