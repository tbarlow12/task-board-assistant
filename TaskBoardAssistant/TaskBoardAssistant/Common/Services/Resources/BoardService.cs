using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;
using TaskBoardAssistant.Common.Models;


namespace TaskBoardAssistant.Common.Services
{
    public abstract class BoardService : ResourceService
    {
        public abstract TaskBoard GetByName(string name);

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
