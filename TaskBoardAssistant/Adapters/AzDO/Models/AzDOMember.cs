
using System;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Models
{
    class AzDOMember : ITaskMember
    {
        public string Username => throw new NotImplementedException();

        public string FullName => throw new NotImplementedException();

        public string Id => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Rename(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
