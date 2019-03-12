using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant.Adapters.Simulators;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services.Resources;

namespace UnitTests
{
    [TestClass]
    public class TestListService
    {
        [TestMethod]
        public void TestFactory()
        {
            FactorySimulator simulator = new FactorySimulator();
            var resourceService = simulator.GetResourceService(ResourceType.List);
            var listService = resourceService as ListService;
            Assert.IsNotNull(listService);
        }
    }
        
}
