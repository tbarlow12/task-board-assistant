using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models.Resources;


namespace TaskBoardAssistant.Common.Services
{
    public abstract class BoardService : ResourceService
    {
        public abstract TaskBoard GetByName(string name);
    }
}
