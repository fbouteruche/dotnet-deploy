using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DotnetDeploy
{
    public class AzureFunctionDeploymentManager : IDeploymentManager
    {
        private const string projectTypeArgumentExceptionMessage = "The parameter projectType cannot be null, empty or blank";

        private const string projectFileNameArgumentExceptionMessage = "The parameter projectFileName cannot be null, empty or blanc";

        public bool Deploy(string projectType, string projectFileName, Dictionary<string, string> deploymentOptions)
        {
            if (string.IsNullOrWhiteSpace(projectType))
            {
                throw new System.ArgumentException(projectTypeArgumentExceptionMessage, nameof(projectType));
            }

            if (string.IsNullOrWhiteSpace(projectFileName))
            {
                throw new System.ArgumentException(projectFileNameArgumentExceptionMessage, nameof(projectFileName));
            }
            if(projectType == "azurefunction")
            {
                string functionAppName = (deploymentOptions != null && deploymentOptions.ContainsKey("functionAppName")) ? deploymentOptions["functionAppName"] : String.Empty;
                
                Process func = Process.Start("func", String.Format("azure functionapp publish {0}", functionAppName));
                func.WaitForExit();
                return (func.ExitCode == 0);
            }
            return false;
        }
    }
}