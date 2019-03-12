
using System;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public sealed class AzDOService
    {
        private static readonly Lazy<AzDOService> lazy = new Lazy<AzDOService>(() => new AzDOService());

        public static AzDOService Instance { get => lazy.Value; }

        private AzDOService() { }

        public object Factory
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task CommitResources()
        {
            throw new NotImplementedException();
        }
    }
}
