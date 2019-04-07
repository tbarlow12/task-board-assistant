using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloLabelService : LabelService
    {
        TrelloService trello;

        private static readonly Lazy<TrelloLabelService> lazy = new Lazy<TrelloLabelService>(() => new TrelloLabelService());
        public static TrelloLabelService Instance { get => lazy.Value; }

        private TrelloLabelService()
        {
            Factory = TrelloServiceFactory.Instance;
            trello = TrelloService.Instance;
        }

        public override Task CommitResources()
        {
            return trello.CommitResources();
        }
        public override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }
        public override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null, Dictionary<string, string> queryParams = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
