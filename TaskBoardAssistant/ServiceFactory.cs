using System;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Adapters.Trello;
using TaskBoardAssistant.Adapters.Simulators;

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
                case ServiceProvider.Simulator:
                    return new FactorySimulator();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
