using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Models;


namespace TaskBoardAssistant.Services
{
    public abstract class BoardService : ResourceService
    {
        public abstract ITaskBoard GetByName(string name);

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
