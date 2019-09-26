using System;
using System.Collections.Generic;

namespace DotnetDeploy
{
    public class GCPProvider : IHostingProvider
    {
        public bool Deploy(Dictionary<string, string> deploymentOptions) => throw new NotImplementedException();
    } 
}