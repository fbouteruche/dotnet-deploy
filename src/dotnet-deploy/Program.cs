using System;
using System.Xml;
using System.IO;

namespace DotnetDeploy
{
    class Program
    {
        private const string notSupportedMessage = "Not supported project type";
        private const string azureFunctionType = "azurefunction";
        private const string noProjectFileMessage = "No project file in the current folder";

        static void Main(string[] args)
        {
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Dotnet-deploy deployment tool version 0.1 for .NET Core.");
            Console.WriteLine("This tool is distributed under the MIT licence and the source code is available on GitHub");
            Console.WriteLine("https://github.com/fbouteruche/dotnet-deploy");
            Console.WriteLine();

            string[] projectFileNames = DetectProjectFiles();
            if (projectFileNames.Length == 0)
            {
                Console.WriteLine(noProjectFileMessage);
                return;
            }

            string selectedProjectFile = SelectProjectFile(projectFileNames);
            Console.WriteLine("Selected project file: {0}", selectedProjectFile);
            
            string projectType = DetectProjectType(selectedProjectFile);
            if(projectType == String.Empty)
            {
                Console.WriteLine(value: notSupportedMessage);
                return;
            }

            DeployProject(projectType, selectedProjectFile);
            return; 
        }

        private static void DeployProject(string projectType, string selectedProjectFile)
        {
            CompositeDeploymentManager deploymentManager = new CompositeDeploymentManager(
                new AzureFunctionDeploymentManager());
            
            if(!deploymentManager.Deploy(projectType, selectedProjectFile))
            {
                Console.WriteLine("Unable to deploy project type");
            }
        }

        private static string DetectProjectType(string selectedProjectFile)
        {
            XmlDocument csproj = new XmlDocument();
            csproj.Load(selectedProjectFile);
            CompositeProjectTypeClassifier classifier = new CompositeProjectTypeClassifier(
                new AzureFunctionProjectTypeClassifier());
            
            return classifier.Classify(csproj);
        }

        private static string SelectProjectFile(string[] projectFileNames)
        {
            string result;
            if (projectFileNames.Length == 0)
            {
                result = String.Empty;
            }
            else if (projectFileNames.Length == 1)
            {
                result = projectFileNames[0];
            }
            else
            {
                Console.WriteLine("Please, select the project file to use:");
                for (int i = 0; i < projectFileNames.Length; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, projectFileNames[i]);
                }
                result = ReadUserSelection(projectFileNames);
            }
            return result;
        }

        private static string ReadUserSelection(string[] projectFileNames)
        {
            string result;
            Console.Write("Enter your selection: ");
            string userSelection = Console.ReadLine();
            int selection = -1;
            if (int.TryParse(userSelection, out selection) && selection > 0 && selection <= projectFileNames.Length)
            {
                result = projectFileNames[selection - 1];
            }
            else
            {
                Console.WriteLine("Your selection must be an integer between 1 and {0}.", projectFileNames.Length);
                result = ReadUserSelection(projectFileNames);
            }

            return result;
        }

        private static string[] DetectProjectFiles()
        {
            return Directory.GetFiles(".", "*.csproj");
        }
    }
}
