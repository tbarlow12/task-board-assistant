using Manatee.Trello;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.Trello.Services;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Trello.Models
{
    public class TrelloList : ITaskList
    {
        public TrelloList(IList list)
        {
            List = list;
        }
        public IList List { get; private set; }

        public IEnumerable<ITaskCard> Cards => GetCards().Result;


        public async Task<IEnumerable<ITaskCard>> GetCards()
        {
            await List.Cards.Refresh();
            var result = new List<ITaskCard>();
            foreach(var card in List.Cards)
            {
                result.Add(new TrelloCard(card));
            }
            return result;
        }
        public string Id => List.Id;

        public string Name { get => List.Name; set => List.Name = value; }

        public bool Archived { get => (bool)List.IsArchived; set => List.IsArchived = value; }

        public async Task<TrelloCard> AddCard(string name, string desc, string due, string members, string labels)
        {
            var dueDate = due.ToDateTime();
            if (dueDate == null)
                dueDate = due.ToRelativeDateTime();
            List<ILabel> labelList = null;
            if (labels != null)
            {
                var labelService = TrelloLabelService.Instance;
                labelList = new List<ILabel>();
                var labelSplit = labels.Split(',');
                foreach(var labelName in labelSplit)
                {
                    TrelloLabel label = await labelService.GetByName(List.Board, labelName);
                    labelList.Add(label.Label);
                }
            }
            List<IMember> memberList = null;
            if (members != null)
            {
                var memberService = TrelloMemberService.Instance;
                memberList = new List<IMember>();
                var memberSplit = members.Split('.');
                foreach(var memberName in memberSplit)
                {
                    TrelloMember member = await memberService.GetByUsername(List.Board, memberName);
                    memberList.Add(member.Member);
                }
            }
            var card = await List.Cards.Add(name, description: desc, dueDate: dueDate, labels: labelList, members: memberList);
            return new TrelloCard(card);
        }

        public Task SortList(BaseAction action)
        {
            var cards = Cards;
            return Task.CompletedTask;
        }

        async Task<ITaskResource> ITaskList.AddCard(BaseAction action)
        {
            var name = action.Params.GetValueOrDefault("name");
            var desc = action.Params.GetValueOrDefault("desc");
            var due = action.Params.GetValueOrDefault("due");
            var members = action.Params.GetValueOrDefault("assignedTo");
            var labels = action.Params.GetValueOrDefault("labels");
            return await AddCard(name, desc, due, members, labels);
        }

        public Task Archive()
        {
            Archived = true;
            return Task.CompletedTask;
        }

        public Task Rename(string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}
