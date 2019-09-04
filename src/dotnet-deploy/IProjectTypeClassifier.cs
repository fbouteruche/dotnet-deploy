using System.Xml;

namespace DotnetDeploy
{
    public interface IProjectTypeClassifier
    {
        string Classify(XmlDocument csproj);
    }
}