using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Services;
using TaskBoardAssistant.Models;

namespace TaskBoardAssistant
{
    public class Assistant
    {
        private delegate PolicyCollection PolicyLoader(string path);
        private static PolicyLoader GetPolicyLoader(string policyPath)
        {
            if (policyPath.EndsWith(".json"))
            {
                return new PolicyLoader(PolicyService.JsonFromFile);
            }
            else if (policyPath.EndsWith(".yml") || policyPath.EndsWith(".yaml"))
            {
                return new PolicyLoader(PolicyService.YmlFromFile);
            }
            else
            {
                throw new Exception("Invalid file type for policy. Use .json, .yml or .yaml");
            }
        }

        public static IEnumerable<PolicyResult> Execute(string policyPath, string credsPath)
        {
            var collection = GetPolicyLoader(policyPath)(policyPath);
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider, credsPath);
            List<PolicyResult> results = new List<PolicyResult>();
            foreach (var p in collection.Policies)
            {
                var resourceService = factory.GetResourceService(p.Resource);
                results.Add(resourceService.ExecutePolicy(p).Result);
            }
            return results;
        }
    }
}
