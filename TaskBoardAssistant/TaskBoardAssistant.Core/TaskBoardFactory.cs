﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Models;
using TaskBoardAssistant.Services;

namespace TaskBoardAssistant
{
    public abstract class TaskBoardFactory
    {
        public ResourceService GetResourceService(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Board:
                    return GetBoardService();
                case ResourceType.List:
                    return GetListService();
                case ResourceType.Card:
                    return GetCardService();
                case ResourceType.Label:
                    return GetListService();
                default:
                    throw new NotImplementedException();
            }
        }
        public abstract BoardService GetBoardService();
        public abstract ListService GetListService();
        public abstract CardService GetCardService();
        public abstract LabelService GetLabelService();
    }
}