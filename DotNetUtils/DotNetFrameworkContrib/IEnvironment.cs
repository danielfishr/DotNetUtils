namespace DotNetUtils.DotNetFrameworkContrib
{
    using System.Collections;

    public interface IEnvironment
    {
        void Exit(int code);
        string GetEnvironmentVariable(string key);
        IDictionary GetEnvironmentVariable();
    }
}