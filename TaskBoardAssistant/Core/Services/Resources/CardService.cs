using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;


namespace TaskBoardAssistant.Core.Services.Resources
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

        public async Task Move(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            var listService = Factory.GetListService();
            var list = listService.GetList(action.Params["board"], action.Params["list"]);
            foreach(var resource in resources)
            {
                await ((ITaskCard)resource).MoveTo(list);
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

        public override bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter)
        {
            return filter.Name.IsNullOrEqualsIgnoreCase(resource.Name);
        }

        public override async Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            switch (action.Type)
            {
                case ResourceAction.Move:
                    await Move(resources, action);
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
