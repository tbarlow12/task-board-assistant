using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public class AzDOLabelService : LabelService
    {
        AzDOService github;

        private static readonly Lazy<AzDOLabelService> lazy = new Lazy<AzDOLabelService>();

        public static AzDOLabelService Instance { get => lazy.Value; }

        private AzDOLabelService()
        {
            github = AzDOService.Instance;
            Factory = AzDOServiceFactory.Instance;
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
            return github.CommitResources();
        }
    }
}
