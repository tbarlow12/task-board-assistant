using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Adapters.Simulators;
using TaskBoardAssistant.Adapters.Simulators.Services;
using System.Linq;
using TaskBoardAssistant.Core.Services.Resources;

namespace UnitTests
{
    [TestClass]
    public class TestLabelService
    {
        [TestMethod]
        public void TestFactory()
        {
            FactorySimulator simulator = new FactorySimulator();
            var resourceService = simulator.GetResourceService(ResourceType.Label);
            var labelService = resourceService as LabelService;
            Assert.IsNotNull(labelService);
        }
    }
        
}
