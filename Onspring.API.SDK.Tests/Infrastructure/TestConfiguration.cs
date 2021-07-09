using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Infrastructure
{
    [ExcludeFromCodeCoverage]
    internal class TestConfiguration
    {
        public string ApiKey { get; private set; }
        public string BaseAddress { get; private set; }
        public ClientType ClientType { get; private set; }

        private TestConfiguration()
        {
        }

        public static TestConfiguration LoadFromContext(TestContext testContext)
        {
            var didClientParse = Enum.TryParse<ClientType>(testContext.Properties["ClientType"]?.ToString(), out var clientType);

            return new TestConfiguration
            {
                ApiKey = testContext.Properties["ApiKey"]?.ToString(),
                BaseAddress = testContext.Properties["BaseAddress"]?.ToString(),
                ClientType = didClientParse ? clientType : ClientType.Internal,
            };
        }
    }
}
