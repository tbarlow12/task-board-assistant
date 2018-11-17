using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Simulators.Models
{
    public abstract class ResourceSimulator : ITaskResource
    {
        public string Id => throw new NotImplementedException();

        public string Name { get; set; }

        public Task Rename(string newName)
        {
            Name = newName;
            return Task.CompletedTask;
        }
    }
}
