using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardAssistant.Common.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Newtonsoft.Json;

namespace TaskBoardAssistant.Common.Services
{
    public static class PolicyService
    {
        public static List<Policy> YmlFromString(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            return deserializer.Deserialize<List<Policy>>(new StringReader(yaml));
        }

        public static List<Policy> YmlFromFile(string path)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            return deserializer.Deserialize<List<Policy>>(File.OpenText(path));
        }

        public static List<Policy> GetPoliciesFromBlob(string blob)
        {
            throw new NotImplementedException();
        }

        public static List<Policy> JsonFromString(string json)
        {
            return JsonConvert.DeserializeObject<List<Policy>>(json);
        }

        public static List<Policy> JsonFromFile(string path)
        {
            return JsonFromString(File.ReadAllText(path));
        }
    }
}
