using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Trello;
using TaskBoardAssistant.Trello.Models;
using TaskBoardAssistant;
using TaskBoardAssistant.Services;

namespace UnitTests
{
    [TestClass]
    public class TestTrello
    {
        public const string PolicyDirPath = "../../Policies/";

        [TestMethod]
        public void TestGetAllBoards()
        {
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(ServiceProvider.Trello);
            var boardService = factory.GetBoardService();
            var boards = boardService.GetResources().Result.ToList();
            Assert.IsTrue(boards.Count > 0);
        }

        public TrelloList Doing
        {
            get
            {

            }
        }

        [TestMethod]
        public void TestArchiveDone()
        {
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(ServiceProvider.Trello);

            
            


            Assistant.ExecuteFromPath(PolicyDirPath + "ArchiveDone.json");
        }

        [TestMethod]
        public void TestCreateCards()
        {
            Assistant.ExecuteFromPath(PolicyDirPath + "CreateCards.yml");
        }

        [TestMethod]
        public void TestDailyEmail()
        {
            Assistant.ExecuteFromPath(PolicyDirPath + "DailyEmail.yml");
        }

        [TestMethod]
        public void TestInactiveCards()
        {
            Assistant.ExecuteFromPath(PolicyDirPath + "InactiveCards.yml");
        }

        [TestMethod]
        public void TestSortDueDate()
        {
            Assistant.ExecuteFromPath(PolicyDirPath + "SortDueDate.yml");
        }

        [TestMethod]
        public void TestSortName()
        {
            Assistant.ExecuteFromPath(PolicyDirPath + "SortName.yml");
        }
    }
}
