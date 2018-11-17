using Manatee.Trello;
using System;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    class TrelloMember : ITaskBoardMember
    {
        public TrelloMember(IMember member)
        {
            Member = member;
        }

        public IMember Member { get; set; }

        public string Username { get => Member.UserName; set => throw new InvalidOperationException("Can't set a member's username"); }

        public string Id => Member.Id;

        public string Name { get => Member.FullName; set => throw new InvalidOperationException("Can't set a member's name"); }

        public string FullName => Member.FullName;

        public Task Rename(string newName)
        {
            throw new InvalidOperationException("Can't rename a member");
        }
    }
}
