using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant;
using TaskBoardAssistant.Adapters.Simulators;
using TaskBoardAssistant.Core.Services;

namespace UnitTests
{
    [TestClass]
    public class TestEndToEnd
    {
        string PolicyDir = "../../../Policies/";
        FactorySimulator factory = new FactorySimulator();

        [TestMethod]
        public void TestArchivePolicy()
        {
            var listService = factory.GetListService();
            var list = listService.GetList("personal", "done").Result;
            foreach(var card in list.Cards)
            {
                Assert.IsFalse(card.IsArchived);
            }
            Assistant.ExecuteFromPath(PolicyDir + "ArchiveDone.yml");
            foreach(var card in list.Cards)
            {
                Assert.IsTrue(card.IsArchived);
            }
        }
    }
}
