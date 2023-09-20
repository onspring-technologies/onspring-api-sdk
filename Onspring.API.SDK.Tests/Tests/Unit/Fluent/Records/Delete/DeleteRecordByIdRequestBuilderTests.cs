using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteRecordByIdRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static DeleteRecordByIdRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteRecordByIdRequestBuilder(_client, 1, 1);
        }

        // TODO: Write tests
    }
}