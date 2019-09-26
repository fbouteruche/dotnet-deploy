using System.Collections.Generic;

namespace DotnetDeploy
{
    public interface IDeploymentManager
    {
        bool Deploy(string projectType,
                    string projectFileName,
                    Dictionary<string, string> deploymentOptions);
    }
}