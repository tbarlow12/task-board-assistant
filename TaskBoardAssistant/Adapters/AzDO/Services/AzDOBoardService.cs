using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public class AzDOBoardService : BoardService
    {
        private static readonly Lazy<AzDOBoardService> lazy = new Lazy<AzDOBoardService>(() => new AzDOBoardService());
        public static AzDOBoardService Instance { get => lazy.Value; }
        private AzDOBoardService(){}

        public override ITaskBoard GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override Task CommitResources()
        {
            throw new NotImplementedException();
        }
    }
}
