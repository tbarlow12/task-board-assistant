using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Core.Services.Resources
{
    public abstract class ResourceService
    {
        // ABSTRACT
        public abstract Task<ITaskResource> GetById(string id);
        public abstract Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null);
        public abstract bool SatisfiesFilter(ITaskResource resource, TaskBoardResourceFilter filter);
        public abstract Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action);
        public abstract Task CommitResources();

        // CONCRETE
        public ITaskBoardFactory Factory { get; set; }
        public async Task<PolicyResult> ExecutePolicy(Models.Policy policy, IEnumerable<ITaskResource> parents = null)
        {
            PolicyResult result = new PolicyResult();
            var resources = await GetResources(policy, parents);
            if (policy.Filters != null)
            {
                result.ResourcesBeforeFilters = resources;
                resources = FilterResources(resources, policy.Filters).ToList();
            }
            result.ResourcesBeforeActions = resources;
            if (policy.Children != null)
            {
                result.ChildrenResults = new List<PolicyResult>();
                foreach (var child in policy.Children)
                {
                    var childResourceService = Factory.GetResourceService(child.Resource);
                    result.ChildrenResults.Add(
                        await childResourceService.ExecutePolicy(child, resources)
                    );
                }
            }
            if (policy.Actions != null)
            {
                foreach (var action in policy.Actions)
                {
                    resources = await PerformAction(resources, action);
                }
                Task.WaitAll(CommitResources());
                result.ResourcesAfterActions = resources;
            }
            return result;
        }
        private async Task<IEnumerable<ITaskResource>> GetResources(Models.Policy policy, IEnumerable<ITaskResource> parents)
        {
            IEnumerable<ITaskResource> resources;
            if (policy.Id != null)
                resources = new List<ITaskResource>
                {
                    await GetById(policy.Id)
                };
            else
            {
                resources = await GetResources(parents);
            }
            return resources;
        }
        public IEnumerable<ITaskResource> FilterResources(IEnumerable<ITaskResource> resources, List<TaskBoardResourceFilter> filters)
        {
            foreach(var f in filters)
            {
                if (resources.IsNullOrEmpty())
                {
                    return resources;
                }
                resources = FilterResources(resources, f);
            }
            return resources;
        }
        private IEnumerable<ITaskResource> FilterResources(IEnumerable<ITaskResource> resources, TaskBoardResourceFilter filter)
        {
            foreach (var resource in resources)
            {
                if (SatisfiesFilter(resource, filter))
                {
                    yield return resource;
                }
            }
        }

        // ACTIONS
        public void Rename(IEnumerable<ITaskResource> resources, BaseAction action)
        {
            foreach (var resource in resources)
            {
                resource.Rename(
                    action.Params.GetKeyOrThrow("name", 
                    $"Need a new name for resource {resource.Name}"));
            }
        }

    }
}
