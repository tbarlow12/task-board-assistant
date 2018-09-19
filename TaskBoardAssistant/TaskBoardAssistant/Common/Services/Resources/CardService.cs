using System;
using System.Collections.Generic;
using TaskBoardAssistant.Common.Models.Resources;
using TaskBoardAssistant.Common.Models;

namespace TaskBoardAssistant.Common.Services
{
    public abstract class CardService : ResourceService
    {
        public void Archive(IEnumerable<ITaskResource> resources)
        {
            foreach(var resource in resources)
            {
                ((TaskCard)resource).Archive();
            }
        }
        public IEnumerable<TaskCard> Create(BaseAction action)
        {
            var listService = Factory.GetListService();
            var list = listService.GetList(action.Params["board"], action.Params["list"]);
            var card = list.CreateCard(action).Result;
            yield return card;
        }

        public void Move(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            var listService = Factory.GetListService();
            var list = listService.GetList(action.Params["board"], action.Params["list"]);
            foreach(var resource in resources)
            {
                ((TaskCard)resource).MoveTo(list);
            }
        }

        public void AddLabel(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            var labelService = Factory.GetLabelService();
            var label = labelService.GetLabel(action.Params["board"], action.Params["label"]);
            foreach(var resource in resources)
            {
                ((TaskCard)resource).AddLabel(label);
            }
        }

        public override IEnumerable<ITaskResource> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            switch (action.Type)
            {
                case ResourceAction.Move:
                    Move(resources, action);
                    break;
                case ResourceAction.Archive:
                    Archive(resources);
                    break;
                case ResourceAction.Label:
                    AddLabel(resources, action);
                    break;
                default:
                    throw new Exception($"The {action.Type} action is not permitted for a card");
            }
            CommitResources();
            return resources;
        }      
    }
}
