using McMaster.Extensions.CommandLineUtils;

namespace DotnetDeploy
{
    public class GCPSubCommand : CommandLineApplication
    {
        public GCPSubCommand()
        {
            this.Name = "gcp";
            this.HelpOption(true);
            this.UsePagerForHelpText = false;

            this.OnExecute(() =>
            {
                IHostingProvider hostingProvider = HostingProviderFactory.GetProvider("gcp");
                if(hostingProvider != null)
                {
                    bool success = hostingProvider.Deploy(null);
                }
            });
        }
    }
}