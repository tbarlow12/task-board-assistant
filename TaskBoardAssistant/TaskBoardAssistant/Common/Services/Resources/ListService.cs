using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Common.Models.Resources;

namespace TaskBoardAssistant.Common.Services
{
    public abstract class ListService : ResourceService
    {
        public TaskList GetList(string boardName, string listName)
        {
            var boardService = Factory.GetBoardService();
            var board = boardService.GetByName(boardName);
            return GetList(board, listName);
        }

        public TaskList GetList(TaskBoard board, string listName)
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
                //Not sure why this works, but without the .Result,
                //the last card in the policy is ski
                //var card = ((TaskList)resource).CreateCard(action).Result;
                ((TaskList)resource).CreateCard(action);
            }
        }
    }
}
