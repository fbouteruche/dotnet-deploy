using System.Xml;

namespace DotnetDeploy
{
    public class AzureFunctionProjectTypeClassifier : IProjectTypeClassifier 
    {
        public string Classify(XmlDocument csproj)
        {
            if (csproj.SelectNodes("//PackageReference[@Include='Microsoft.NET.Sdk.Functions']").Count > 0)
            {
                return "azurefunction";
            }
            return string.Empty;
        }
    }
}