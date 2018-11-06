using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Services;
using TaskBoardAssistant.Models.Resources;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant.Services
{
    public abstract class ResourceService
    {
        public TaskBoardFactory Factory { get; set; }
        public async Task<PolicyResult> ExecutePolicy(Policy policy, IEnumerable<ITaskResource> parents = null)
        {
            PolicyResult result = new PolicyResult();
            var resources = await GetResources(policy, parents);
            if (policy.Filters != null)
            {
                result.ResourcesBeforeFilters = resources;
                resources = FilterResources(resources, policy.Filters).ToList();
            }
            result.ResourcesBeforeActions = resources;
            if(policy.Children != null)
            {
                result.ChildrenResults = new List<PolicyResult>();
                foreach(var child in policy.Children)
                {
                    var childResourceService = Factory.GetResourceService(child.Resource);
                    result.ChildrenResults.Add(
                        await childResourceService.ExecutePolicy(child, resources)
                    );
                }
            }
            if(policy.Actions != null)
            {
                foreach(var action in policy.Actions)
                {
                    resources = await PerformAction(resources, action);
                }
                Task.WaitAll(CommitResources());
                result.ResourcesAfterActions = resources;
            }
            return result; 
        }
        public IEnumerable<ITaskResource> FilterResources(
            IEnumerable<ITaskResource> resources, List<TaskBoardResourceFilter> filters)
        {
            foreach (var resource in resources)
                foreach(var filter in filters)
                    if (resource.SatisfiesFilter(filter))
                        yield return resource;
        }
        public abstract Task<ITaskResource> GetById(string id);
        private async Task<IEnumerable<ITaskResource>> GetResources(Policy policy, IEnumerable<ITaskResource> parents)
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
        public abstract Task<IEnumerable<ITaskResource>> GetResources(IEnumerable<ITaskResource> parents = null);
        public abstract Task<IEnumerable<ITaskResource>> PerformAction(IEnumerable<ITaskResource> resources, BaseAction action);
        public abstract Task CommitResources();
    }
}
