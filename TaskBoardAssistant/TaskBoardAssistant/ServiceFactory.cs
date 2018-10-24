using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Trello;

namespace TaskBoardAssistant
{
    public class ServiceFactory
    {
        public TaskBoardFactory GetTaskBoardFactory(ServiceProvider provider, string secretsPath)
        {
            switch (provider)
            {
                case ServiceProvider.Trello:
                    return new TrelloServiceFactory(secretsPath);
                default:
                    throw new NotImplementedException();
            }
        }

        public TaskBoardFactory GetTaskBoardFactory(ServiceProvider provider)
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
