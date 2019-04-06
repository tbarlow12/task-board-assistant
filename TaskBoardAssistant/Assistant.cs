using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Core;
using TaskBoardAssistant.Core.Models;
using TaskBoardAssistant.Core.Services;
using TaskBoardAssistant.Core.Services.Policy;

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

        private static async Task<PolicyCollection> LoadPoliciesFromBlob(string connectionString, string containerName, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            string text;
            using (var memoryStream = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(memoryStream);
                text = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            if (fileName.ToLower().EndsWith("json"))
            {
                return PolicyService.JsonFromString(text);
            }
            else if(fileName.ToLower().EndsWith("yml") || fileName.ToLower().EndsWith("yaml"))
            {
                return PolicyService.YmlFromString(text);
            }
            else
            {
                throw new InvalidDataException("Invalid file extension. Make sure file ext is .json, .yml or .yaml");
            }
        }

        public static IEnumerable<PolicyResult> ExecuteFromPath(string fileName)
        {
            var policies = LoadPoliciesFromPath(fileName);
            return Execute(policies);
        }

        public static IEnumerable<PolicyResult> ExecuteFromBlob(string connectionString, string containerName, string fileName)
        {
            var policies = LoadPoliciesFromBlob(connectionString, containerName, fileName).Result;
            return Execute(policies);
        }

        public static IEnumerable<PolicyResult> ExecuteFromYmlString(string policies)
        {
            return Execute(PolicyService.YmlFromString(policies));
        }

        public static IEnumerable<PolicyResult> ExecuteFromJsonString(string policies)
        {
            return Execute(PolicyService.JsonFromString(policies));
        }

        public static IEnumerable<PolicyResult> ExecuteFromYmlPath(string path)
        {
            return Execute(PolicyService.YmlFromFile(path));
        }

        public static IEnumerable<PolicyResult> ExecuteFromJsonPath(string path)
        {
            return Execute(PolicyService.JsonFromFile(path));
        }

        private static IEnumerable<PolicyResult> Execute(PolicyCollection collection)
        {
            ServiceFactory serviceFactory = new ServiceFactory();
            ITaskBoardFactory factory = serviceFactory.GetTaskBoardFactory(collection.Provider);
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
