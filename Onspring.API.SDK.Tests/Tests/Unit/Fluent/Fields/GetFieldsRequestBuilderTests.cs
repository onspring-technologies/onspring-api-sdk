using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetFieldsRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static readonly int _fieldId = 1;
        private static readonly IEnumerable<int> _fieldIds = new[] { 1, 2, 3 };
        private static IOnspringClient _client;
        private static GetFieldsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetFieldsRequestBuilder(_client);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var builder = _builder.FromApp(_appId);

            Assert.IsInstanceOfType<IGetFieldsByAppRequestBuilder>(builder);
            Assert.AreEqual(_appId, builder.AppId);
        }

        [TestMethod]
        public void WithId_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var builder = _builder.WithId(_fieldId);

            Assert.IsInstanceOfType<IGetFieldByIdRequestBuilder>(builder);
            Assert.AreEqual(_appId, builder.FieldId);
        }

        [TestMethod]
        public void WithIds_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var builder = _builder.WithIds(_fieldIds);

            Assert.IsInstanceOfType<IGetFieldsByIdsRequestBuilder>(builder);
            Assert.AreEqual(_fieldIds, builder.FieldIds);
        }
    }
}