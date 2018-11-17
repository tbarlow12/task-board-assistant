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
            return new BoardServiceSimulator(this);
        }

        public CardService GetCardService()
        {
            return new CardServiceSimulator(this);
        }

        public LabelService GetLabelService()
        {
            return new LabelServiceSimulator(this);
        }

        public ListService GetListService()
        {
            return new ListServiceSimulator(this);
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
