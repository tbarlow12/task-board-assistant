using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Trello.Models;
using Manatee.Trello;

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
        public async override Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null, Dictionary<string, string> queryParams = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }

        public override Task<ITaskResource> GetByName(string name)
        {
            throw new InvalidOperationException();
        }

        public async Task<TrelloLabel> GetByName(IBoard board, string name)
        {
            await board.Labels.Refresh();
            foreach(var label in board.Labels)
            {
                if (label.Name.EqualsIgnoreCase(name))
                {
                    return new TrelloLabel(label);
                }
            }
            return null;
        }
    }
}
