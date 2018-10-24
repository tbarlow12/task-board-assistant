using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Models.Resources;

namespace TaskBoardAssistant.Services
{
    public abstract class ListService : ResourceService
    {
        public ITaskList GetList(string boardName, string listName)
        {
            var boardService = Factory.GetBoardService();
            var board = boardService.GetByName(boardName);
            return GetList(board, listName);
        }

        public ITaskList GetList(ITaskBoard board, string listName)
        {
            foreach(var list in board.Lists)
            {
                if (list.Name.ToLower().Equals(listName.ToLower()))
                    return list;
            }
            throw new Exception($"Couldn't find a list in {board.Name} with the name {listName}");
        }

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            switch (action.Type)
            {
                case ResourceAction.AddCard:
                    AddCard(resources, action);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return resources;
        }

        private void AddCard(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            foreach(var resource in resources)
            {
                ((ITaskList)resource).CreateCard(action);
            }
        }
    }
}
