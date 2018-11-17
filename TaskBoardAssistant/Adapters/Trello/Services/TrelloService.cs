using Manatee.Trello;
using System;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Adapters.Trello.Services
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
