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
        private static PolicyCollection LoadPoliciesFromPath(string policyPath)
        {
            PolicyLoader loader;
            if (policyPath.EndsWith(".json"))
            {
                loader = new PolicyLoader(PolicyService.JsonFromFile);
            }
            else if (policyPath.EndsWith(".yml") || policyPath.EndsWith(".yaml"))
            {
                loader = new PolicyLoader(PolicyService.YmlFromFile);
            }
            else
            {
                throw new Exception("Invalid file type for policy. Use .json, .yml or .yaml");
            }
            return loader(policyPath);
        }

        private static PolicyCollection LoadPoliciesFromBlob(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<PolicyResult> ExecuteFromPath(string fileName)
        {
            var policies = LoadPoliciesFromPath(fileName);
            return Execute(policies);
        }

        public static IEnumerable<PolicyResult> ExecuteFromBlob(string container, string fileName)
        {
            var policies = LoadPoliciesFromBlob(container, fileName);
            return Execute(policies);
        }

        private static IEnumerable<PolicyResult> Execute(PolicyCollection collection)
        {
            ServiceFactory serviceFactory = new ServiceFactory();
            TaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider);
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
