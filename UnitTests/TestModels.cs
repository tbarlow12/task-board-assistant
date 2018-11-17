using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TaskBoardAssistant.Adapters.Simulators;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services.Resources;
using TaskBoardAssistant.Adapters.Simulators.Services;

namespace UnitTests
{
    [TestClass]
    public class TestModels
    {
        [TestMethod]
        public void TestFilterEquality()
        {
            TaskBoardResourceFilter f1 = new TaskBoardResourceFilter
            {
                Archived = false,
                Name = "Filter",
                Open = true
            };

            TaskBoardResourceFilter f2 = new TaskBoardResourceFilter
            {
                Archived = false,
                Name = "Filter",
                Open = true
            };
            Assert.AreEqual(f1, f2);
            TaskBoardResourceFilter f3 = new TaskBoardResourceFilter
            {
                Archived = false,
                Name = "blah",
                Open = true
            };
            Assert.AreNotEqual(f1, f3);
        }
        [TestMethod]
        public void TestActionEquality()
        {

        }
    }
        
}
