using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.Simulators.Models
{
    class BoardSimulator : ResourceSimulator, ITaskBoard 
    {
        List<ListSimulator> _lists;

        public BoardSimulator(string name)
        {
            Name = name;
            _lists = new List<ListSimulator>
            {
                new ListSimulator("To Do"),
                new ListSimulator("Doing"),
                new ListSimulator("Done")
            };
        }
        public BoardSimulator(string name, List<ListSimulator> lists)
        {
            Name = name;
            _lists = lists;
        }




        public IEnumerable<ITaskList> Lists { get => _lists; set => _lists = value as List<ListSimulator>; }

        public IEnumerable<ITaskBoardMember> Members => throw new NotImplementedException();

        public bool IsOpen { get; set; }


        public Task Close()
        {
            throw new NotImplementedException();
        }

        public Task Open()
        {
            throw new NotImplementedException();
        }
    }
}
