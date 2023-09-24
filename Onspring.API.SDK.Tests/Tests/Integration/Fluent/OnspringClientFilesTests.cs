using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientFilesTests
    {
        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task GetFile()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFile()
                .FromRecord(1)
                .InField(1)
                .WithId(1)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task GetFileInfo()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToGetFileInfo()
                .FromRecord(1)
                .InField(1)
                .WithId(1)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task DeleteFile()
        {
            var apiResponse = await _apiClient
                .CreateRequest()
                .ToDeleteFile()
                .FromRecord(1)
                .InField(1)
                .WithId(1)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }

        [TestMethod]
        public async Task AddFile()
        {
            var filePath = TestHelper.GetDefaultImagePath();
            var fileStream = File.OpenRead(filePath);

            var apiResponse = await _apiClient
                .CreateRequest()
                .ToAddFile()
                .ToRecord(1)
                .InField(1)
                .WithName("image")
                .WithStream(fileStream)
                .WithType("image/png")
                .WithNotes("This is a test file")
                .WithModifiedDate(DateTime.UtcNow)
                .SendAsync();

            AssertHelper.AssertSuccess(apiResponse);
        }
    }
}