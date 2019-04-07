
using System;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Github.Models
{
    public class GithubLabel : ITaskLabel
    {
        public string Id => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Rename(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
