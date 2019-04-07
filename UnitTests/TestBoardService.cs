using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Adapters.Simulators;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Services;

namespace UnitTests
{
    [TestClass]
    public class TestBoardService
    {
        [TestMethod]
        public void TestFactory()
        {
            FactorySimulator simulator = new FactorySimulator();
            var resourceService = simulator.GetResourceService(ResourceType.Board);
            var boardService = resourceService as BoardService;
            Assert.IsNotNull(boardService);
        }
        [TestMethod]
        public void TestNameFilter()
        {
            var boardService = new BoardServiceSimulator();
            var filters = new List<TaskBoardResourceFilter>
            {
                new TaskBoardResourceFilter
                {
                    Name = "Test Board 1"
                }
            };
            var boards = boardService.GetResources().Result;
            var filtered = boardService.FilterResources(boards, filters).ToList();
            Assert.AreEqual(1, filtered.Count);
        }

        [TestMethod]
        public void TestClosedFilter()
        {

            var boardService = new BoardServiceSimulator();
            var filters = new List<TaskBoardResourceFilter>
            {
                new TaskBoardResourceFilter
                {
                    Open = true
                }
            };
            var boards = boardService.GetResources().Result;
            var filtered = boardService.FilterResources(boards, filters).ToList();
            Assert.AreEqual(2, filtered.Count);
        }

        [TestMethod]
        public void TestOpenFilter()
        {

            var boardService = new BoardServiceSimulator();
            var filters = new List<TaskBoardResourceFilter>
            {
                new TaskBoardResourceFilter
                {
                    Open = false
                }
            };
            var boards = boardService.GetResources().Result;
            var filtered = boardService.FilterResources(boards, filters).ToList();
            Assert.AreEqual(1, filtered.Count);
        }
    }
        
}
