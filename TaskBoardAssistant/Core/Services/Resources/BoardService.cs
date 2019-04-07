using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;


namespace TaskBoardAssistant.Core.Services.Resources
{
    public abstract class BoardService : ResourceService
    {
        public abstract ITaskBoard GetByName(string name);
        public override bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter)
        {
            var board = (ITaskBoard)resource;
            return filter.Name.IsNullOrEqualsIgnoreCase(board.Name) &&
                filter.Open.IsNullOrEquals(board.IsOpen);
        }
    }
}
