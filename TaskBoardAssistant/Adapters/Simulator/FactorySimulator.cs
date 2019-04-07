using TaskBoardAssistant.Adapters.Simulators.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;

namespace TaskBoardAssistant.Adapters.Simulators
{
    public class FactorySimulator : ITaskBoardFactory
    {
        public BoardService BoardService => new BoardServiceSimulator();

        public ListService ListService => new ListServiceSimulator();

        public CardService CardService => new CardServiceSimulator();

        public LabelService LabelService => new LabelServiceSimulator();
    }
}
