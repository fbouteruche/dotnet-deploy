using System;
using System.Diagnostics;

namespace DotnetDeploy
{
    public class AzureFunctionDeploymentManager : IDeploymentManager
    {
        private const string projectTypeArgumentExceptionMessage = "The parameter projectType cannot be null, empty or blank";

        private const string projectFileNameArgumentExceptionMessage = "The parameter projectFileName cannot be null, empty or blanc";

        public bool Deploy(string projectType, string projectFileName)
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
                Console.WriteLine("now we have to really deploy it");
                Process.Start("func", "azure functionapp publish").WaitForExit();
                Console.WriteLine("after call to func");
                return true;
            }
            return false;
        }
    }
}