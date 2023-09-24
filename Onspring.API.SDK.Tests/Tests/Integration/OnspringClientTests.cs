using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;
using Onspring.API.SDK.Tests.Infrastructure;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Onspring.API.SDK.Tests.Tests.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientTests
    {
        private static TestConfiguration _testConfiguration;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testConfiguration = TestConfiguration.LoadFromContext(testContext);
        }

        [TestMethod]
        public void ValidConstructor_BaseAddress_ApiKey()
        {
            var _ = new OnspringClient(_testConfiguration.BaseAddress, _testConfiguration.ApiKey);
        }

        [DataTestMethod]
        [DataRow((string)null, "testkey")]
        [DataRow("", "testkey")]
        [DataRow("        ", "testkey")]
        [DataRow("notarealurl.", "testkey")]
        [DataRow("http://localhost", (string)null)]
        [DataRow("http://localhost", "")]
        [DataRow("http://localhost", "        ")]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidConstructor_BaseAddress_ApiKey(string baseAddress, string apiKey)
        {
            var _ = new OnspringClient(baseAddress, apiKey);
        }

        [TestMethod]
        public void ValidConstructor_ClientConfiguration()
        {
            var clientConfig = new OnspringClientConfiguration(_testConfiguration.BaseAddress, _testConfiguration.ApiKey);
            var _ = new OnspringClient(clientConfig);
        }

        [DataTestMethod]
        [DataRow((string)null, "testkey")]
        [DataRow("", "testkey")]
        [DataRow("        ", "testkey")]
        [DataRow("notarealurl.", "testkey")]
        [DataRow("http://localhost", (string)null)]
        [DataRow("http://localhost", "")]
        [DataRow("http://localhost", "        ")]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidConstructor_ClientConfiguration(string baseAddress, string apiKey)
        {
            var clientConfig = new OnspringClientConfiguration
            {
                BaseAddress = baseAddress,
                ApiKey = apiKey
            };

            var _ = new OnspringClient(clientConfig);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidConstructor_NullClientConfiguration()
        {
            var _ = new OnspringClient(null);
        }

        [TestMethod]
        public void ValidConstructor_ApiKey_HttpClient()
        {
            var _ = new OnspringClient(_testConfiguration.ApiKey, new HttpClient { BaseAddress = new Uri(_testConfiguration.BaseAddress) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidConstructor_NullHttpClient()
        {
            var _ = new OnspringClient(_testConfiguration.ApiKey, httpClient: null);
        }

        [DataTestMethod]
        [DataRow((string)null)]
        [DataRow("")]
        [DataRow("        ")]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidConstructor_InvalidApiKey_HttpClient(string apiKey)
        {
            var _ = new OnspringClient(apiKey, new HttpClient { BaseAddress = new Uri(_testConfiguration.BaseAddress) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidConstructor_HttpClient_NoBaseAddress()
        {
            var _ = new OnspringClient(_testConfiguration.ApiKey, new HttpClient());
        }

        [TestMethod]
        public void CreateRequest_WhenCalled_ItShouldReturnAnInstanceOfAnOnspringRequest()
        {
            var client = new OnspringClient(_testConfiguration.ApiKey, new HttpClient { BaseAddress = new Uri(_testConfiguration.BaseAddress) });
            var request = client.CreateRequest();
            Assert.IsInstanceOfType<IOnspringRequestBuilder>(request);
        }
    }
}