using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Trello.Services;
using Manatee.Trello;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant.Trello.Models
{
    public class TrelloCard : ITaskCard
    {
        public TrelloCard(ICard card)
        {
            Card = card;
        }
        public ICard Card { get; private set; }
        public string Description
        {
            get => Card.Description;
            set => Card.Description = value;
        }
        public DateTime? DueDate
        {
            get => Card.DueDate;
            set => Card.DueDate = value;
        }

        public IEnumerable<ITaskLabel> Labels => GetLabels().Result;

        // PRIVATE HELPERS
        private async Task<IEnumerable<ITaskLabel>> GetLabels()
        {
            await Card.Labels.Refresh();
            var result = new List<ITaskLabel>();
            foreach (var label in Card.Labels)
            {
                result.Add(new TrelloLabel(label));
            }
            return result;
        }

        public IEnumerable<string> Comments => GetComments().Result;

        private async Task<IEnumerable<string>> GetComments()
        {
            throw new NotImplementedException();
        }

        public string Id => Card.Id;

        public string Name
        {
            get => Card.Name;
            set => Card.Name = value;
        }

        public void AddComment(string comment)
        {
            Card.Comments.Add(comment);
        }

        public void AddLabel(ITaskLabel label)
        {
            Card.Labels.Add(((TrelloLabel)label).Label);
        }

        public bool Archived { get => (bool) Card.IsArchived; set => Card.IsArchived = value; }

        public void Archive()
        {
            Card.IsArchived = true;
        }

        public void MoveTo(ITaskList list)
        {
            Card.List = ((TrelloList)list).List;
        }

        public bool SatisfiesFilter(TaskBoardResourceFilter filter)
        {
            if (filter.Name != null && !Name.ToLower().Equals(filter.Name.ToLower()))
                return false;
            if (filter.Archived != null && !(bool)filter.Archived == Card.IsArchived)
                return false;
            return true;
        }

        public void Unarchive()
        {
            Card.IsArchived = false;
        }
        /*
public string Description { get => Card.Description; set => Card.Description = value; }
public DateTime? DueDate { get => Card.DueDate; set => Card.DueDate = value; }

public IEnumerable<ITaskLabel> Labels => throw new NotImplementedException();

public IEnumerable<string> Comments => throw new NotImplementedException();

public string Id => Card.Id;

public string Name { get => Card.Name; set => Card.Name = value; }

public void AddComment(string comment)
{
   throw new NotImplementedException();
}

public void AddLabel(ITaskLabel label)
{
   throw new NotImplementedException();
}

public void Archive()
{
   throw new NotImplementedException();
}

public void MoveTo(TaskList list)
{
   throw new NotImplementedException();
}

public bool SatisfiesFilter(TaskBoardResourceFilter filter)
{
   throw new NotImplementedException();
}

public void Unarchive()
{
   throw new NotImplementedException();
}

/*
// PROPERTIES
public override string Id => Card.Id; 
public override string Name { get => Card.Name; set => Card.Name = value; }
public override IEnumerable<TaskLabel> Labels => GetLabels().Result;
public override string Description { get => Card.Description; set => Card.Description = value; }
public override DateTime? DueDate { get => Card.DueDate; set => Card.DueDate = value; }
public override IEnumerable<string> Comments {
   get
   {
       foreach(var comment in Card.Comments)
       {
           yield return comment.ToString();
       }
   }
}

// PRIVATE HELPERS
private async Task<IEnumerable<TaskLabel>> GetLabels()
{
   await Card.Labels.Refresh();
   var result = new List<TaskLabel>();
   foreach(var label in Card.Labels)
   {
       result.Add(new TrelloLabel(label));
   }
   return result;
}
// OPERATIONS
public override void MoveTo(TaskList list)
{
   var trelloList = (TrelloList)list;
   Card.List = trelloList.List;
}
public override void Archive()
{
   Card.IsArchived = true;
}

public override void Unarchive()
{
   Card.IsArchived = false;
}

public override void AddComment(string comment)
{
   Card.Comments.Add(comment);
}
public override void AddLabel(TaskLabel label)
{
   var trelloLabel = (TrelloLabel)label;
   Card.Labels.Add(trelloLabel.Label);
}
*/
    }
}
