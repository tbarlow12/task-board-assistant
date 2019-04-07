using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Trello.Models;
using Manatee.Trello;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloMemberService : MemberService
    {
        TrelloService trello;

        private static readonly Lazy<TrelloMemberService> lazy = new Lazy<TrelloMemberService>(() => new TrelloMemberService());
        public static TrelloMemberService Instance { get => lazy.Value; }

        private TrelloMemberService()
        {
            Factory = TrelloServiceFactory.Instance;
            trello = TrelloService.Instance;
        }

        public override Task CommitResources()
        {
            return trello.CommitResources();
        }
        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }
        public async override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null, Dictionary<string, string> queryParams = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override Task<ITaskResource> GetByName(string name)
        {
            throw new InvalidOperationException();
        }

        public async Task<TrelloMember> GetByUsername(IBoard board, string name)
        {
            await board.Members.Refresh();
            foreach (var Member in board.Members)
            {
                if (Member.UserName.EqualsIgnoreCase(name))
                {
                    return new TrelloMember(Member);
                }
            }
            return null;
        }
    }
}
