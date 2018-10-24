﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello;
using Manatee.Trello.Rest;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.WebApi;
using System.IO;
using Newtonsoft.Json;

namespace TaskBoardAssistant.Trello
{
    public class TrelloConfig
    {
        public static void Initialize(string appKey, string userToken)
        {
            TrelloAuthorization.Default.AppKey = appKey;
            TrelloAuthorization.Default.UserToken = userToken;
        }
        public static void Initialize(string path)
        {
            var json = File.ReadAllText(path);
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Initialize(values["TRELLO_APP_KEY"], values["TRELLO_USER_TOKEN"]);
        }

        public static void Initialize()
        {
            Initialize(
                Environment.GetEnvironmentVariable("TRELLO_APP_KEY"),
                Environment.GetEnvironmentVariable("TRELLO_USER_TOKEN")
            );
        }
    }
}