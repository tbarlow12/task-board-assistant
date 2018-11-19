using System;
using System.Collections.Generic;
using System.Text;
using TaskBoardAssistant.Adapters.Simulators.Models;
using TaskBoardAssistant.Core.Models.Resources;
using TaskBoardAssistant.Core.Services;


namespace TaskBoardAssistant.Adapters.Simulators
{
    public sealed class DataRepo
    {
        private static readonly Lazy<DataRepo> lazy = new Lazy<DataRepo>(() => new DataRepo());
        public static DataRepo Instance { get => lazy.Value; }
        List<BoardSimulator> data;

        private List<ListSimulator> GetTestLists()
        {
            var toDo = new ListSimulator("To do");
            toDo.AddCard("Test Card 1");
            toDo.AddCard("Test Card 2");

            var doing = new ListSimulator("Doing");
            toDo.AddCard("Test Card 3");
            toDo.AddCard("Test Card 4");

            var done = new ListSimulator("Done");
            toDo.AddCard("Test Card 5");
            toDo.AddCard("Test Card 6");

            return new List<ListSimulator>
            {
                toDo, doing, done
            };
        }
        private DataRepo()
        {
            data = new List<BoardSimulator>
            {
                new BoardSimulator("Personal", GetTestLists()),
                new BoardSimulator("Work", GetTestLists()),
                new BoardSimulator("Project", GetTestLists())
            };
        }

        internal IEnumerable<ITaskBoard> GetAllBoards()
        {
            return data;
        }

        internal IEnumerable<ITaskList> GetAllLists()
        {
            return GetAllBoards().ListsInBoards();
        }

        internal IEnumerable<ITaskCard> GetAllCards()
        {
            return GetAllLists().CardsInLists();
        }

        internal IEnumerable<ITaskLabel> GetAllLabels()
        {
            return GetAllCards().LabelsInCards();
        }
    }
}
