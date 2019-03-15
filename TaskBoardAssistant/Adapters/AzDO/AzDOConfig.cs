using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TaskBoardAssistant.Adapters.AzDO
{
    public class AzDOConfig
    {
        public static string PersonalAccessToken { get; private set; }
        public static string CollectionUri { get; private set; }
        public static void Initialize()
        {
            PersonalAccessToken = Environment.GetEnvironmentVariable("AZDO_PAT");
            CollectionUri = Environment.GetEnvironmentVariable("AZDO_COLLECTION");
        }
    }
}
