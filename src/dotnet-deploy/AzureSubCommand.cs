using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace DotnetDeploy
{
    public class AzureSubCommand : CommandLineApplication
    {
        public AzureSubCommand()
        {
            this.Name = "azure";
            this.HelpOption(true);
            this.UsePagerForHelpText = false;

            CommandOption functionAppName = this.Option("-f | --functionAppName", "FunctionAppName used to deploy", CommandOptionType.SingleValue);
            


            this.OnExecute(() =>
            {
                IHostingProvider hostingProvider = HostingProviderFactory.GetProvider("azure");
                if(hostingProvider != null)
                {
                    Dictionary<string, string> deploymentOptions = new Dictionary<string, string>();
                    if(functionAppName.HasValue())
                    {
                        deploymentOptions.Add("functionAppName", functionAppName.Value());
                    }   

                    bool success = hostingProvider.Deploy(deploymentOptions);
                }
            });
        }
    }
}