using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TaskBoardAssistant.Adapters.Github
{
    public class GithubConfig
    {
        public static string Username { get; private set; }
        public static string DefaultRepo { get; private set; }
        public static string Token { get; private set; }
        public static void Initialize()
        {
            Username = Environment.GetEnvironmentVariable("GITHUB_USERNAME");
            Token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        }
    }
}
