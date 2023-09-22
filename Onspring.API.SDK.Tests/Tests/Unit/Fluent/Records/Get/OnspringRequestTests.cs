using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringRequestTests
    {
        private static OnspringRequest _onspringRequest;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var apiClientMock = Substitute.For<IOnspringClient>();
            _onspringRequest = new OnspringRequest(apiClientMock);
        }

        [TestMethod]
        public void ToGetRecords_WhenCalled_ShouldReturnAGetRecordsRequestBuilderInstance()
        {
            var builder = _onspringRequest.ToGetRecords();

            Assert.IsInstanceOfType<IGetRecordsRequestBuilder>(builder);
        }
    }
}