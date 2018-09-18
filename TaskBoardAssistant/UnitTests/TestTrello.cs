using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant.Common.Models;
using TaskBoardAssistant.Adapters.Trello;
using TaskBoardAssistant;
using TaskBoardAssistant.Common.Services;

namespace UnitTests
{
    [TestClass]
    public class TestTrello
    {
        public const string PolicyDirPath = "../../TestPolicies/";

        [TestMethod]
        public void TestGetAllBoards()
        {
            ServiceFactory factory = new TrelloServiceFactory("../../secrets.json");
            var boardService = factory.GetBoardService();
            var resources = boardService.GetResources().ToList();
            Assert.IsTrue(resources.Count > 0);
        }

        [TestMethod]
        public void TestRun()
        {
            var policies = PolicyService.JsonFromFile(PolicyDirPath + "ArchiveDone.json");
            ServiceFactory factory = new TrelloServiceFactory("../../secrets.json");
            List<PolicyResult> results = new List<PolicyResult>();
            foreach(var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p));
            }
            Assert.IsTrue(true);
        }
    }
}
