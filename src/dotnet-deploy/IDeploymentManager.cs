namespace DotnetDeploy
{
    public interface IDeploymentManager
    {
        bool Deploy(string projectType,
                    string projectFileName);
    }
}