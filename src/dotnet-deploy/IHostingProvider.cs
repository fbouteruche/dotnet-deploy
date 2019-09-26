using System.Collections.Generic;

namespace DotnetDeploy
{
    public interface IHostingProvider
    {
        bool Deploy(Dictionary<string, string> deploymentOptions);
    }
}