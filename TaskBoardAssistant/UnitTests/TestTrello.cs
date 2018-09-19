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
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(ServiceProvider.Trello, SecretsPath);
            var boardService = factory.GetBoardService();
            var resources = boardService.GetResources().ToList();
            Assert.IsTrue(resources.Count > 0);
        }

        [TestMethod]
        public void TestArchiveDone()
        {
            var collection = PolicyService.JsonFromFile(PolicyDirPath + "ArchiveDone.json");
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider, SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach(var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestCreateCards()
        {
            var collection = PolicyService.YmlFromFile(PolicyDirPath + "CreateCards.yml");
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider, SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDailyEmail()
        {
            var collection = PolicyService.YmlFromFile(PolicyDirPath + "DailyEmail.yml");
            TaskBoardFactory factory = new TrelloServiceFactory(SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestInactiveCards()
        {
            var collection = PolicyService.YmlFromFile(PolicyDirPath + "InactiveCards.yml");
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider, SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestSortDueDate()
        {
            var collection = PolicyService.YmlFromFile(PolicyDirPath + "SortDueDate.yml");
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider, SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }

        [TestMethod]
        public void TestSortName()
        {
            var collection = PolicyService.YmlFromFile(PolicyDirPath + "SortName.yml");
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider, SecretsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
        }
    }
}
