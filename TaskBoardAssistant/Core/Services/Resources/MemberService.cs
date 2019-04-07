using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Core.Services.Resources
{
    public abstract class MemberService : ResourceService
    {
        public async Task<ITaskMember> GetMember(string boardName, string MemberName)
        {
            var boardService = Factory.BoardService;
            var board = await boardService.GetByName(boardName);
            return GetMember((ITaskBoard)board, MemberName);
        }

        public ITaskMember GetMember(ITaskBoard board, string MemberName)
        {
            throw new NotImplementedException();
        }

        public override bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter)
        {
            return filter.Name.IsNullOrEqualsIgnoreCase(resource.Name);
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

    }
}
