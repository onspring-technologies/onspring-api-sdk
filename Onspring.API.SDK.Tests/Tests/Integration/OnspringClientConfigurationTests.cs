using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientConfigurationTests
    {
        [TestMethod]
        public void ParameterlessCtor_GetAndSetParams()
        {
            string apiKey = Guid.NewGuid().ToString();
            const string baseAddress = "https://localhost";

            var clientConfig = new OnspringClientConfiguration
            {
                ApiKey = apiKey,
                BaseAddress = baseAddress,
                JsonSerializer = new Newtonsoft.Json.JsonSerializer()
            };

            Assert.AreEqual(apiKey, clientConfig.ApiKey, "ApiKey was not correct");
            Assert.AreEqual(baseAddress, clientConfig.BaseAddress, "BaseAddress was not correct");
        }

        [TestMethod]
        public void ParameteredCtor_GetParams()
        {
            string apiKey = Guid.NewGuid().ToString();
            const string baseAddress = "https://localhost";

            var clientConfig = new OnspringClientConfiguration(baseAddress, apiKey);

            Assert.AreEqual(apiKey, clientConfig.ApiKey, "ApiKey was not correct");
            Assert.AreEqual(baseAddress, clientConfig.BaseAddress, "BaseAddress was not correct");
        }
    }
}