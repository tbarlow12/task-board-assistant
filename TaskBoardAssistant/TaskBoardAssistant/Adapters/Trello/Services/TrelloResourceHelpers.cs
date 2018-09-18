using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Adapters.Trello.Models;
using TaskBoardAssistant.Common.Services;


namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public static class TrelloResourceExtensions
    {
        public static IMe GetMe(this TrelloFactory factory)
        {
            var me = factory.Me();
            return me.Result;
        }
        public static async Task<IEnumerable<IBoard>> GetAllMyBoards(this IMe me)
        {
            var boards = me.Boards;
            await boards.Refresh();
            return boards;
        }

        public static IEnumerable<IList> GetAllMyLists(this IMe me)
        {
            var boards = me.GetAllMyBoards().Result;
            List<Task> TaskList = new List<Task>();
            foreach(var board in boards)
            {
                TaskList.Add(board.GetBoardLists());
            }
            Task.WaitAll(TaskList.ToArray());
            foreach (var task in TaskList)
            {
                var result = ((Task<IEnumerable<IList>>)task).Result;
                foreach (var list in result)
                    yield return list;
            }
        }

        public static IEnumerable<ICard> GetAllMyCards(this IMe me)
        {
            var lists = me.GetAllMyLists();
            List<Task> TaskList = new List<Task>();
            foreach(var list in lists)
            {
                TaskList.Add(list.GetListCards());
            }
            Task.WaitAll(TaskList.ToArray());
            foreach(var task in TaskList)
            {
                var result = ((Task<IEnumerable<ICard>>)task).Result;
                foreach (var card in result)
                    yield return card;
            }
        }

        public static IEnumerable<ILabel> GetAllMyLabels(this IMe me)
        {
            var cards = me.GetAllMyCards();
            List<Task> TaskList = new List<Task>();
            foreach(var card in cards)
            {
                TaskList.Add(card.GetCardLabels());
            }
            Task.WaitAll(TaskList.ToArray());
            foreach(var task in TaskList)
            {
                var result = ((Task<IEnumerable<ILabel>>)task).Result;
                foreach(var label in result)
                {
                    yield return label;
                }
            }
        }

        public static async Task<IEnumerable<IList>> GetBoardLists(this IBoard board)
        {
            var lists = board.Lists;
            if(lists.IsNullOrEmpty())
                await lists.Refresh();
            return lists;
        }

        public static async Task<IEnumerable<ICard>> GetListCards(this IList list)
        {
            var cards = list.Cards;
            if(cards.IsNullOrEmpty())
                await cards.Refresh();
            return cards;
        }
        public static async Task<IEnumerable<ILabel>> GetCardLabels(this ICard card)
        {
            var labels = card.Labels;
            if(labels.IsNullOrEmpty())
                await labels.Refresh();
            return labels;
        }
        public static IList ByName(this IListCollection lists, string name)
        {
            foreach (IList list in lists)
            {
                if (list.Name.Equals(name))
                {
                    return list;
                }
            }
            return null;
        }
        public static ILabel ByName(this ICardLabelCollection labels, string name)
        {
            foreach (ILabel label in labels)
            {
                if (label.Name.Equals(name))
                {
                    return label;
                }
            }
            return null;
        }

        public static bool HasLabel(this ICard card, ILabel label)
        {
            foreach(ILabel l in card.Labels)
            {
                if (l.Equals(label))
                    return true;
            }
            return true;
        }

        public static bool HasLabel(this ICard card, string name)
        {
            return card.Labels.ByName(name) != null;
        }

        public static void MoveTo(this ICard card, IList list, int position = 1)
        {
            card.List = list;
            card.Position = position;
        }

        public static void AddLabel(this ICard card, ILabel label)
        {
            if (!card.HasLabel(label.Name))
            {
                card.Labels.Add(label);
            }
        }

        public static void Archive(this ICard card)
        {
            card.IsArchived = true;
        }
    }
}
