namespace DotNetUtils.DotNetFrameworkContrib
{
    using System;
    using System.Collections;

    //allow abstraction of environment
    public class RealEnvironmnet : IEnvironment
    {
        public void Exit(int code)
        {
            Environment.Exit(code);
        }

        public string GetEnvironmentVariable(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }

        public IDictionary GetEnvironmentVariable()
        {
            return Environment.GetEnvironmentVariables();
        }
    }
}