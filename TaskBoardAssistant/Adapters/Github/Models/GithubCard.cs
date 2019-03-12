
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Github.Models
{
    public class GithubCard : ITaskCard
    {
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DueDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<ITaskLabel> Labels => throw new NotImplementedException();

        public IEnumerable<string> Comments => throw new NotImplementedException();

        public bool IsArchived { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Id => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task AddComment(string comment)
        {
            throw new NotImplementedException();
        }

        public Task AddLabel(ITaskLabel label)
        {
            throw new NotImplementedException();
        }

        public Task Archive()
        {
            throw new NotImplementedException();
        }

        public Task MoveTo(ITaskList list)
        {
            throw new NotImplementedException();
        }

        public Task Rename(string newName)
        {
            throw new NotImplementedException();
        }

        public Task SetPosition(int i)
        {
            throw new NotImplementedException();
        }

        public Task Unarchive()
        {
            throw new NotImplementedException();
        }
    }
}
