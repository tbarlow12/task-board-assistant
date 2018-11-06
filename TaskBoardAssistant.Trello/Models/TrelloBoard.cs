using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant.Trello.Models
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

        public bool Closed { get => (bool)Board.IsClosed; set => Board.IsClosed = value; }

        public void Close()
        {
            Board.IsClosed = true;
        }

        public void Open()
        {
            Board.IsClosed = false;
        }

        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            if (filter.Name != null && !Name.ToLower().Equals(filter.Name.ToLower()))
                return false;
            if(filter.Closed != null && !(bool)filter.Closed == Closed)
                return false;
            return true;
        }
        /*
public override string Id { get => Board.Id; }
public override string Name { get => Board.Name; set => Board.Name = value; }
public override IEnumerable<ITaskList> Lists => GetLists().Result;
public override IEnumerable<ITaskBoardMember> Members => GetMembers().Result; 



public override void Close()
{
   Board.IsClosed = true;
}
public override void Open()
{
   Board.IsClosed = false;
}

public bool SatisfiesFilter(TaskBoardResourceFilter filter)
{
   throw new NotImplementedException();
}
*/
    }
}
