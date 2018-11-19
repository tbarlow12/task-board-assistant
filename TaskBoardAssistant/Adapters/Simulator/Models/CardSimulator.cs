using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Simulators.Models
{
    class CardSimulator : ResourceSimulator, ITaskCard
    {
        List<string> _comments;
        List<ITaskLabel> _labels;

        public CardSimulator(ITaskList list, string name)
        {
            Name = name;
            List = list;
            _comments = new List<string>();
            _labels = new List<ITaskLabel>();
        }
        public CardSimulator() { }

        public CardSimulator(ITaskList list, string name, string desc, string due, string member)
        {
            List = list;
            Name = name;
            Description = desc;
            DueDate = due.ToDateTime();
            if (DueDate == null)
                DueDate = due.ToRelativeDateTime();
        }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public IEnumerable<ITaskLabel> Labels => _labels;
        public IEnumerable<string> Comments => _comments;
        public bool IsArchived { get; set; }
        public ITaskList List { get; set; }
        public int Position { get; set; }

        public Task AddComment(string comment)
        {
            _comments.Add(comment);
            return Task.CompletedTask;
        }

        public Task AddLabel(ITaskLabel label)
        {
            _labels.Add(label);
            return Task.CompletedTask;
        }

        public Task Archive()
        {
            IsArchived = true;
            return Task.CompletedTask;
        }

        public Task MoveTo(ITaskList list)
        {
            List = list;
            return Task.CompletedTask;
        }

        public Task SetPosition(int i)
        {
            Position = i;
            return Task.CompletedTask;
        }

        public Task Unarchive()
        {
            IsArchived = false;
            return Task.CompletedTask;
        }
    }
}
