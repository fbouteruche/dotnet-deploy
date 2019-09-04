using System;
using System.Xml;
using System.Collections.Generic;

namespace DotnetDeploy
{
    public class CompositeProjectTypeClassifier : IProjectTypeClassifier
    {
        private readonly IList<IProjectTypeClassifier> classifiers = new List<IProjectTypeClassifier>();
        public CompositeProjectTypeClassifier(params IProjectTypeClassifier[] projectTypeClassifiers)
        {
            if (projectTypeClassifiers is null)
            {
                throw new ArgumentNullException(nameof(projectTypeClassifiers));
            }
            for(int i = 0; i < projectTypeClassifiers.Length; i++)
            {
                classifiers.Add(projectTypeClassifiers[i]);
            }
        }

        public string Classify(XmlDocument csproj)
        {
            string projectType = String.Empty;
            for(int i = 0; i < classifiers.Count; i++)
            {
                projectType = classifiers[i].Classify(csproj);   
                if(projectType == string.Empty)
                {
                    return projectType;
                }
            }
            return projectType;
        }
    }
}