
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoardAssistant.Adapters.AzDO.Models;
using TaskBoardAssistant.Core.Models.Resources;

namespace TaskBoardAssistant.Adapters.AzDO.Services
{
    public sealed class AzDOService
    {
        private static readonly Lazy<AzDOService> lazy = new Lazy<AzDOService>(() => new AzDOService());
        public static AzDOService Instance { get => lazy.Value; }
        public WorkItemTrackingHttpClient Client { get; private set; }

        private AzDOService()
        {
            VssConnection connection = new VssConnection(new Uri(AzDOConfig.CollectionUri), new VssBasicCredential(string.Empty, AzDOConfig.PersonalAccessToken));
            Client = connection.GetClient<WorkItemTrackingHttpClient>();
        }
    }
}
