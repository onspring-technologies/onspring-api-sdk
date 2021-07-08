using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientFilesTests
    {
        private const int _fieldId = 1;
        private const int _recordId = 1;
        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task SaveReadDeleteFileAsync()
        {
            // Save file
            var filePath = TestHelper.GetDefaultImagePath();
            var saveFileRequest = new SaveFileRequest
            {
                FieldId = _fieldId,
                RecordId = _recordId,
                FileStream = File.OpenRead(filePath),
                FileName = Path.GetFileName(filePath),
                ContentType = "image/png",
                ModifiedDate = DateTime.UtcNow,
                Notes = "Test file."
            };

            var saveResponse = await _apiClient.SaveFileAsync(saveFileRequest);
            AssertHelper.AssertSuccess(saveResponse);

            var fileId = saveResponse.Value.Id;

            // Get info
            var getFileInfoResponse = await _apiClient.GetFileInfoAsync(_recordId, _fieldId, fileId);
            AssertHelper.AssertSuccess(getFileInfoResponse);

            // Get raw file back
            var getFileResponse = await _apiClient.GetFileAsync(_recordId, _fieldId, fileId);
            AssertHelper.AssertSuccess(getFileResponse);

            // Delete file
            var deleteResponse = await _apiClient.DeleteFileAsync(_recordId, _fieldId, fileId);
            AssertHelper.AssertSuccess(deleteResponse);
        }
    }
}
