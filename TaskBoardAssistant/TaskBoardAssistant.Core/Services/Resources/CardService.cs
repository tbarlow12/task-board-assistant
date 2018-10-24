using System;
using System.Collections.Generic;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Models;
using System.Threading.Tasks;


namespace TaskBoardAssistant.Services
{
    public abstract class CardService : ResourceService
    {
        public void Archive(IEnumerable<ITaskResource> resources)
        {
            foreach(var resource in resources)
            {
                ((ITaskCard)resource).Archive();
            }
        }

        public void Move(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            var listService = Factory.GetListService();
            var list = listService.GetList(action.Params["board"], action.Params["list"]);
            foreach(var resource in resources)
            {
                ((ITaskCard)resource).MoveTo(list);
            }
        }

        public void AddLabel(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            var labelService = Factory.GetLabelService();
            var label = labelService.GetLabel(action.Params["board"], action.Params["label"]);
            foreach(var resource in resources)
            {
                ((ITaskCard)resource).AddLabel(label);
            }
        }

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
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
            return resources;
        }      
    }
}
