using Microsoft.Extensions.Configuration;

namespace Microbians.Core.Configuration
{
    /// <summary>
    /// Configuration Helpers
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// Helps non asp.net apps/tests to find the configuration used
        /// </summary>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public static IConfigurationRoot GetConfigurationRoot(string outputPath = "")
        {
            if (string.IsNullOrEmpty(outputPath))
                outputPath = Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("appx") // todo  - figure out how to parameterize this
                .AddEnvironmentVariables()
                .Build();
        }
    }
}