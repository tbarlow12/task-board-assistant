using Manatee.Trello;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.Trello.Models;
using TaskBoardAssistant.Core.Services;


namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public static class TrelloResourceExtensions
    {
        public static IMe GetMe(this TrelloFactory factory)
        {
            var me = factory.Me();
            return me.Result;
        }
        public static async Task<IEnumerable<IBoard>> GetAllMyBoards(this IMe me, bool refresh = false)
        {
            var boards = me.Boards;
            if(refresh)
                await boards.Refresh();
            return boards;
        }

        public static async Task<IEnumerable<IList>> GetAllMyLists(this IMe me)
        {
            var result = new List<IList>();
            var boards = await me.GetAllMyBoards();
            foreach(var board in boards)
            {
                var boardLists = await board.GetBoardLists();
                result.AddRange(boardLists);
            }
            return result;
        }

        public static async Task<IEnumerable<ICard>> GetAllMyCards(this IMe me)
        {
            var result = new List<ICard>();
            var lists = await me.GetAllMyLists();
            foreach(var list in lists)
            {
                var listCards = await list.GetListCards();
                result.AddRange(listCards);
            }
            return result;
        }

        public static async Task<IEnumerable<ILabel>> GetAllMyLabels(this IMe me)
        {
            var result = new List<ILabel>();
            var cards = await me.GetAllMyCards();
            foreach(var card in cards)
            {
                var cardLabels = await card.GetCardLabels();
                result.AddRange(cardLabels);
            }
            return result;
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

        public static IEnumerable<TrelloBoard> ToTrelloBoards(this IEnumerable<IBoard> boards)
        {
            foreach(var board in boards)
            {
                yield return new TrelloBoard(board);
            }
        }

        public static IEnumerable<TrelloList> ToTrelloLists(this IEnumerable<IList> lists)
        {
            foreach(var list in lists)
            {
                yield return new TrelloList(list);
            }
        }

        public static IEnumerable<TrelloCard> ToTrelloCards(this IEnumerable<ICard> cards)
        {
            foreach(var card in cards)
            {
                yield return new TrelloCard(card);
            }
        }

        public static IEnumerable<TrelloLabel> ToTrelloLabels(this IEnumerable<ILabel> labels)
        {
            foreach(var label in labels)
            {
                yield return new TrelloLabel(label);
            }
        }
    }
}
