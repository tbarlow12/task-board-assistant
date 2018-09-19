using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Common.Models.Resources;
using TaskBoardAssistant.Common.Services;
using TaskBoardAssistant.Adapters.Trello.Models;
using Manatee.Trello;

namespace TaskBoardAssistant.Adapters.Trello.Services
{
    public class TrelloLabelService : LabelService
    {
        IMe me;
        TrelloFactory trelloFactory;

        public TrelloLabelService(TrelloServiceFactory factory)
        {
            Factory = factory;
            trelloFactory = new TrelloFactory();
            me = trelloFactory.Me().Result;
        }

        public override void CommitResources()
        {
            Task t = TrelloProcessor.Flush();
            while (!t.IsCompleted) { }
        }
        public async override Task<ITaskResource> GetById(string id)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<ITaskResource> GetResources(IEnumerable<ITaskResource> parents = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ITaskResource> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            throw new NotImplementedException();
        }
    }
}
