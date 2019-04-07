using System;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Adapters.Trello;
using TaskBoardAssistant.Adapters.Github;
using TaskBoardAssistant.Adapters.AzDO;

namespace TaskBoardAssistant
{
    public class ServiceFactory
    {
        public ITaskBoardFactory GetTaskBoardFactory(ServiceProvider provider)
        {
            switch (provider)
            {
                case ServiceProvider.Trello:
                    return TrelloServiceFactory.Instance;
                case ServiceProvider.Github:
                    return GithubServiceFactory.Instance;
                case ServiceProvider.AzDO:
                    return AzDOServiceFactory.Instance;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
