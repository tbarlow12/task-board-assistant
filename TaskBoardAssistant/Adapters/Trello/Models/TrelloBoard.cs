using Manatee.Trello;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    public class TrelloBoard : ITaskBoard
    {
        public TrelloBoard(IBoard board)
        {
            Board = board;
        }
        
        public IBoard Board { get; private set; }

        public string Id => Board.Id;

        public string Name { get => Board.Name; set => Board.Name = value; }

        public IEnumerable<ITaskList> Lists => GetLists().Result;
        
        public async Task<IEnumerable<ITaskList>> GetLists()
        {
            await Board.Lists.Refresh();
            var result = new List<ITaskList>();
            foreach(var list in Board.Lists)
            {
                result.Add(new TrelloList(list));
            }
            return result;
        }
        public IEnumerable<ITaskBoardMember> Members => GetMembers().Result;

        private async Task<IEnumerable<ITaskBoardMember>> GetMembers()
        {
            await Board.Members.Refresh();
            var result = new List<ITaskBoardMember>();
            foreach (var member in Board.Members)
            {
                result.Add(new TrelloMember(member));
            }
            return result;
        }

        public bool IsOpen { get => !(bool)Board.IsClosed; set => Board.IsClosed = !value; }

        public Task Close()
        {
            Board.IsClosed = true;
            return Task.CompletedTask;
        }

        public Task Open()
        {
            Board.IsClosed = false;
            return Task.CompletedTask;
        }

        public Task Rename(string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}
