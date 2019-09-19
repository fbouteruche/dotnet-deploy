using McMaster.Extensions.CommandLineUtils;

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
                           bool success = hostingProvider.Deploy();
                       }
            });
        }
    }
}