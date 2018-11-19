using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;


namespace TaskBoardAssistant.Core.Services.Resources
{
    public abstract class BoardService : ResourceService
    {
        public override bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter)
        {
            var board = (ITaskBoard)resource;
            return filter.Name.IsNullOrEqualsIgnoreCase(board.Name) &&
                filter.Open.IsNullOrEquals(board.IsOpen);
        }
        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
