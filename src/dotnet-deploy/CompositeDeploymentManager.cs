using System;
using System.Collections.Generic;

namespace DotnetDeploy
{
    public class CompositeDeploymentManager : IDeploymentManager
    {
        private readonly IList<IDeploymentManager> deploymentManagers = new List<IDeploymentManager>();
        public CompositeDeploymentManager(params IDeploymentManager[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            for(int i = 0; i < args.Length; i++)
            {
                deploymentManagers.Add(args[i]);
            }
        }
        public bool Deploy(string projectType,
                           string projectFileName,
                           Dictionary<string, string> deploymentOptions)
        {
            for(int i = 0; i < deploymentManagers.Count; i++)
            {
                if(deploymentManagers[i].Deploy(projectType, projectFileName, deploymentOptions))
                {
                    return true;
                }
            }

            return false;
        }
    }
}