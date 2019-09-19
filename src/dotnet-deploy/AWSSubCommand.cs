using McMaster.Extensions.CommandLineUtils;

namespace DotnetDeploy
{
    public class AWSSubCommand : CommandLineApplication
    {
        public AWSSubCommand()
        {
            this.Name = "aws";
            this.HelpOption(true);
            this.UsePagerForHelpText = false;

            this.OnExecute(() =>
            {
                IHostingProvider hostingProvider = HostingProviderFactory.GetProvider("aws");
                if(hostingProvider != null)
                {
                    bool success = hostingProvider.Deploy();
                }
            });
        }
    }
}