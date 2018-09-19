using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Adapters.Trello;

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
    }
}
