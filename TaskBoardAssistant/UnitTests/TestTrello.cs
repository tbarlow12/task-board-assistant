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
        public const string SecretsPath = "../../../../secrets.json";

        [TestMethod]
        public void TestGetAllBoards()
        {
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            var boardService = factory.GetBoardService();
            var resources = boardService.GetResources().ToList();
            Assert.IsTrue(resources.Count > 0);
        }

        [TestMethod]
        public void TestArchiveDone()
        {
            var policies = PolicyService.JsonFromFile(PolicyDirPath + "ArchiveDone.json");
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach(var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestCreateCards()
        {
            var policies = PolicyService.YmlFromFile(PolicyDirPath + "CreateCards.yml");
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDailyEmail()
        {
            var policies = PolicyService.YmlFromFile(PolicyDirPath + "DailyEmail.yml");
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestInactiveCards()
        {
            var policies = PolicyService.YmlFromFile(PolicyDirPath + "InactiveCards.yml");
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestSortDueDate()
        {
            var policies = PolicyService.YmlFromFile(PolicyDirPath + "SortDueDate.yml");
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestSortName()
        {
            var policies = PolicyService.YmlFromFile(PolicyDirPath + "SortName.yml");
            ServiceFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }
    }
}
