using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Services;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Models.Resources;
using Manatee.Trello;
using TaskBoardAssistant.Trello.Models;
using TaskBoardAssistant.Trello.Services;

namespace TaskBoardAssistant.Trello.Services
{
    public sealed class TrelloService
    {
        private static readonly Lazy<TrelloService> lazy = new Lazy<TrelloService>(() => new TrelloService());

        public static TrelloService Instance { get => lazy.Value; }

        private TrelloService() { }

        IMe me;
        TrelloFactory trelloFactory;

        public async Task<IMe> GetMe()
        {
            if (me == null)
                me = await Factory.Me();
            return me;
        }

        public TrelloFactory Factory
        {
            get
            {
                if (trelloFactory == null)
                {
                    trelloFactory = new TrelloFactory();
                }
                return trelloFactory;
            }
        }

        public Task CommitResources()
        {
            return TrelloProcessor.Flush();
        }
    }
}
