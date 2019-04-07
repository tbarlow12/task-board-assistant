using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Models
{
    public class AzDOBoard : ITaskBoard
    {
        public IEnumerable<ITaskList> Lists => throw new NotImplementedException();

        public IEnumerable<ITaskMember> Members => throw new NotImplementedException();

        public bool IsOpen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Id => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Close()
        {
            throw new NotImplementedException();
        }

        public Task Open()
        {
            throw new NotImplementedException();
        }

        public Task Rename(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
