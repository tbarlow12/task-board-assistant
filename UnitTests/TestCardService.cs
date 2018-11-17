using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Adapters.Simulators;
using TaskBoardAssistant.Adapters.Simulators.Services;
using System.Linq;
using TaskBoardAssistant.Core.Services.Resources;

namespace UnitTests
{
    [TestClass]
    public class TestCardService
    {
        [TestMethod]
        public void TestFactory()
        {
            FactorySimulator simulator = new FactorySimulator();
            var resourceService = simulator.GetResourceService(ResourceType.Card);
            var cardService = resourceService as CardService;
            Assert.IsNotNull(cardService);
        }
    }
        
}
