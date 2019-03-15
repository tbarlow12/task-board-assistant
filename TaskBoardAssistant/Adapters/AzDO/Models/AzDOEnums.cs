using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBoardAssistant.Adapters.AzDO.Models
{
    public enum AzDOType
    {
        Board,
        Sprint,
        Bug,
        Story,
        Task,
        Repo
    }

    public enum AzDOState
    {
        New,
        Committed,
        Approved,
        Done,
        Removed
    }
}
