using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringRequestTests
    {
        private static OnspringRequest _onspringRequest;

        [ClassInitialize]
        public static void ClassInit()
        {
            _onspringRequest = new OnspringClient("https://api.onspring.com", "key")
                .CreateRequest();
        }

        [TestMethod]
        public void ToGetRecords_WhenCalled_ShouldReturnAGetRecordsRequestBuilderInstance()
        {
            var builder = _onspringRequest.ToGetRecords();

            Assert.IsInstanceOfType<GetRecordsRequestBuilder>(builder);
        }
    }
}