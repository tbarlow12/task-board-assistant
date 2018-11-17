using Newtonsoft.Json;
using System;
using System.IO;
using TaskBoardAssistant.Core.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TaskBoardAssistant.Core.Services.Policy
{
    public static class PolicyService
    {
        public static PolicyCollection YmlFromString(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            return deserializer.Deserialize<PolicyCollection>(new StringReader(yaml));
        }

        public static PolicyCollection YmlFromFile(string path)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            return deserializer.Deserialize<PolicyCollection>(File.OpenText(path));
        }

        public static PolicyCollection GetPoliciesFromBlob(string blob)
        {
            throw new NotImplementedException();
        }

        public static PolicyCollection JsonFromString(string json)
        {
            return JsonConvert.DeserializeObject<PolicyCollection>(json);
        }

        public static PolicyCollection JsonFromFile(string path)
        {
            return JsonFromString(File.ReadAllText(path));
        }
    }
}
