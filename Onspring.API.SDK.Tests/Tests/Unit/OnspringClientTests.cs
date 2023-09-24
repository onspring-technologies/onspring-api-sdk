using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Interfaces.Fluent;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientTests
    {
        [TestMethod]
        public void CreateRequest_WhenCalled_ItShouldReturnAnOnspringRequestInstance()
        {
            var client = new OnspringClient("https://api.onspring.com", "key");
            var request = client.CreateRequest();

            Assert.IsInstanceOfType<IOnspringRequestBuilder>(request);
        }
    }
}