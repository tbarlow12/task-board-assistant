using System;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Adapters.Trello;

namespace TaskBoardAssistant
{
    public class ServiceFactory
    {

        public ITaskBoardFactory GetTaskBoardFactory(ServiceProvider provider)
        {
            switch (provider)
            {
                case ServiceProvider.Trello:
                    return new TrelloServiceFactory();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
