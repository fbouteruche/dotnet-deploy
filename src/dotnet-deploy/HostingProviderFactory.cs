namespace DotnetDeploy
{
    public class HostingProviderFactory
    {
        public static IHostingProvider GetProvider(string providerName)
        {
            IHostingProvider provider = providerName switch {
                "aws" => (IHostingProvider)new AWSProvider(),
                "azure" => (IHostingProvider)new AzureProvider(),
                "gcp" => (IHostingProvider)new GCPProvider(),
                _ => null

            };
            return provider;
        }
    }
}