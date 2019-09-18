using System;
using System.Xml;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace DotnetDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineApplication application = new CommandLineApplication{
                Name = "deploy",
                FullName = "dotnet-deploy",
                LongVersionGetter = () => "1.0.0-full",
                ShortVersionGetter = () => "1.0.0",
                Description = @"This tool is distributed under the MIT licence and the source code is available on GitHub
https://github.com/fbouteruche/dotnet-deploy",
            };

            application.HelpOption(true);
            application.UsePagerForHelpText = false;

            CommandOption providerOption = application.Option("-p | --provider", "hosting provider", CommandOptionType.SingleValue).IsRequired();
            providerOption.Accepts().Values("aws", "azure", "gcp");
      
            application.OnExecute(() =>
               {
                   if(providerOption.HasValue())
                   {
                       string providerName = providerOption.Value();
                       IHostingProvider hostingProvider = HostingProviderFactory.GetProvider(providerName);
                       if(hostingProvider != null)
                       {
                           bool success = hostingProvider.Deploy();
                       }
                   }
               });

            application.Execute(args);
        }
    }
}
