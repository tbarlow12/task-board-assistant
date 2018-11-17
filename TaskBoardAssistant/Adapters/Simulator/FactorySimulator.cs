using TaskBoardAssistant.Adapters.Simulators.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;

namespace TaskBoardAssistant.Adapters.Simulators
{
    public class FactorySimulator : ITaskBoardFactory
    {
        public BoardService GetBoardService()
        {
            return new BoardServiceSimulator();
        }

        public CardService GetCardService()
        {
            return new CardServiceSimulator();
        }

        public LabelService GetLabelService()
        {
            return new LabelServiceSimulator();
        }

        public ListService GetListService()
        {
            return new ListServiceSimulator();
        }

        public ResourceService GetResourceService(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Board:
                    return GetBoardService();
                case ResourceType.Card:
                    return GetCardService();
                case ResourceType.List:
                    return GetListService();
                case ResourceType.Label:
                    return GetLabelService();
                default:
                    throw new System.Exception("Invalid Resource type");
            }
        }
    }
}
