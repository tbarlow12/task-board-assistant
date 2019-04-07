using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;

namespace TaskBoardAssistant.Adapters.Github.Models
{
    public class GithubList : ITaskList
    {
        public IEnumerable<ITaskCard> Cards => throw new NotImplementedException();

        public string Id => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<ITaskResource> AddCard(BaseAction action)
        {
            throw new NotImplementedException();
        }

        public Task Archive()
        {
            throw new NotImplementedException();
        }

        public Task Rename(string newName)
        {
            throw new NotImplementedException();
        }

        public Task SortList(BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
