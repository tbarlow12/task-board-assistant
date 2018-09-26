using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;
using Manatee.Trello;

namespace TaskBoardAssistant.Trello.Models
{
    class TrelloMember : TaskBoardMember
    {
        public TrelloMember(IMember member)
        {
            Name = member.FullName;
            Username = member.UserName;
            Id = member.Id;
        }

        public override string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
