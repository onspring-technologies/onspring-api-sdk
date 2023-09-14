using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientFluentTests
    {
        [TestMethod]
        public void CreateRequest_WhenCalled_ItShouldReturnAnInstanceOfAnOnspringRequest()
        {
            var client = new OnspringClient("https://api.onspring.com", "apiKey");
            var request = client.CreateRequest();
            Assert.IsInstanceOfType(request, typeof(OnspringRequest));
        }
    }
}