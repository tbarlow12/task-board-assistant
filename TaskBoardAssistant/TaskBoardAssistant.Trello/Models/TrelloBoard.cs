using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant;

namespace TaskBoardAssistant.Trello.Models
{
    public class TrelloBoard : TaskBoard
    {
        public TrelloBoard(IBoard board)
        {
            Board = board;
        }
        public IBoard Board { get; private set; }
        public override string Id { get => Board.Id; }
        public override string Name { get => Board.Name; set => Board.Name = value; }
        public override IEnumerable<TaskList> Lists => GetLists().Result;
        public override IEnumerable<TaskBoardMember> Members { get => GetMembers().Result; }

        private async Task<IEnumerable<TaskList>> GetLists()
        {
            await Board.Lists.Refresh();
            var result = new List<TaskList>();
            foreach(var list in Board.Lists)
            {
                result.Add(new TrelloList(list));
            }
            return result;
        }
        private async Task<IEnumerable<TaskBoardMember>> GetMembers()
        {
            await Board.Members.Refresh();
            var result = new List<TaskBoardMember>();
            foreach(var member in Board.Members)
            {
                result.Add(new TrelloMember(member));
            }
            return result;
        }
        public override void Close()
        {
            Board.IsClosed = true;
        }
        public override void Open()
        {
            Board.IsClosed = false;
        }
    }
}
