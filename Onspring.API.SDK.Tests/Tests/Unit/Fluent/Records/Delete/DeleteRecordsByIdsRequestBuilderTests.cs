using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteRecordsByIdsRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static DeleteRecordsByIdsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteRecordsByIdsRequestBuilder(_client, 1, new[] { 1, 2, 3 });
        }

        // TODO: Write tests
    }
}