using Microsoft.Extensions.Configuration;
using System;

namespace TestFramework.Environment
{
    public static class Settings
    {
        private static string _browser;
        public static string Browser
        {
            get
            {
                return _browser;
            }
            set
            {
                if (_browser == null)
                {
                    _browser = value;
                }
            }
        }

        private static string _env;
        public static string Env
        {
            get
            {
                return _env;
            }
            set
            {
                if (_env == null)
                {
                    switch (value) 
                    {
                        case "dev":
                            _env = Configurations.DevConfig;
                            break;
                        case "qa":
                            _env = Configurations.QAConfig;
                            break;
                        default:
                            _env = Configurations.DevConfig;
                            break;
                    }
                }
            }
        }

        public static IConfiguration GetConfiguration() => new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(_env)
            .Build();

        internal static class Configurations
        {
            public const string DevConfig = "env.dev.json";
            public const string QAConfig = "env.qa.json";
        }
    }
}
