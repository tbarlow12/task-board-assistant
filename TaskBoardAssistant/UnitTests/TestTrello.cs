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
            Assistant.Execute(PolicyDirPath + "ArchiveDone.json", SecretsPath);
        }

        [TestMethod]
        public void TestCreateCards()
        {
            Assistant.Execute(PolicyDirPath + "CreateCards.yml", SecretsPath);
        }

        [TestMethod]
        public void TestDailyEmail()
        {
            Assistant.Execute(PolicyDirPath + "DailyEmail.yml", SecretsPath);
        }

        [TestMethod]
        public void TestInactiveCards()
        {
            Assistant.Execute(PolicyDirPath + "InactiveCards.yml", SecretsPath);
        }

        [TestMethod]
        public void TestSortDueDate()
        {
            Assistant.Execute(PolicyDirPath + "SortDueDate.yml", SecretsPath);
        }

        [TestMethod]
        public void TestSortName()
        {
            Assistant.Execute(PolicyDirPath + "SortName.yml", SecretsPath);
        }
    }
}
