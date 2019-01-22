using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBoatUnitTest.Logic.Test
{
    public static class TestHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static LifeBoatUnitTestConfiguration GetApplicationConfiguration(string outputPath)
        {
            var configuration = new LifeBoatUnitTestConfiguration();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("LifeBoatUnitTestConfiguration")
                .Bind(configuration);

            return configuration;
        }

        public class LifeBoatUnitTestConfiguration
        {
            public string GoodFileName { get; set; }
        }
    }
}
