using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Services;
using TaskBoardAssistant.Trello.Models;
using Manatee.Trello;

namespace TaskBoardAssistant.Trello.Services
{
    public class TrelloLabelService : LabelService
    {
        TrelloService trello;

        public TrelloLabelService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trello = TrelloService.Instance;
        }

        public override Task CommitResources()
        {
            return trello.CommitResources();
        }
        public async override Task<ITaskResource> GetById(string id)
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
    }
}
