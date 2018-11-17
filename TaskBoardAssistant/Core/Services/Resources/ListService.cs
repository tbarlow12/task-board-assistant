using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Core.Services.Resources
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
        public override bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter)
        {
            return filter.Name.IsNullOrEqualsIgnoreCase(resource.Name);
        }
        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            switch (action.Type)
            {
                case ResourceAction.AddCard:
                    await AddCard(resources, action);
                    return resources;
                case ResourceAction.Archive:
                    await Archive(resources);
                    return resources;
                case ResourceAction.Sort:
                    await Sort(resources, action);
                    return resources;
                case ResourceAction.Rename:
                    Rename(resources, action);
                    return resources;
                default:
                    throw new NotImplementedException();
            }
        }

        private async Task Archive(IEnumerable<ITaskResource> resources)
        {
            foreach(var resource in resources)
            {
                await ((ITaskList)resource).Archive();
            }
        }
        private async Task AddCard(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            foreach(var resource in resources)
            {
                await ((ITaskList)resource).AddCard(action);
            }
        }
        private Task Sort(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            foreach (var resource in resources)
            {
                IEnumerable<ITaskCard> cards = SortCards(((ITaskList)resource).Cards, action.Params);
                UpdatePosition(cards);
            }
            return Task.CompletedTask;
        }
        private IEnumerable<ITaskCard> SortCards(IEnumerable<ITaskCard> cards, Dictionary<string, string> actionParams)
        {
            var desc = actionParams.GetValueOrDefault("desc", null).NotNullAndEquals("true");
            var comp = actionParams.GetKeyOrThrow("comp", "Need 'comp' variable in params of action");
            var customComparer = Comparer<ITaskCard>.Create((c1, c2) =>
            {
                if (comp.Equals("due"))
                {
                    return DateTime.Compare(
                        c1.DueDate ?? DateTime.MinValue,
                        c2.DueDate ?? DateTime.MinValue);
                }
                else if (comp.Equals("name"))
                {
                    return string.Compare(c1.Name, c2.Name);
                }
                else
                {
                    throw new InvalidOperationException("Choose a valid card comparison - due, name");
                }
            });
            if (desc)
            {
                return cards.OrderByDescending(c => c, customComparer);
            }
            else
            {
                return cards.OrderBy(c => c, customComparer);
            }
        }
        private void UpdatePosition(IEnumerable<ITaskCard> cards)
        {
            int i = 0;
            foreach (var card in cards)
            {
                card.SetPosition(i);
                i++;
            }
        }
    }
}
