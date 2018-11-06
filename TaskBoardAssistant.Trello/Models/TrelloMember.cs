using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant.Trello.Models
{
    class TrelloMember : ITaskBoardMember
    {
        public TrelloMember(IMember member)
        {
            Member = member;
        }

        public IMember Member { get; set; }

        public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Id => Member.Id;

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            throw new NotImplementedException();
        }

        /*
        public override string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        */
    }
}
