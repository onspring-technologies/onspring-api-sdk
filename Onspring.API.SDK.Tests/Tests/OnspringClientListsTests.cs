using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientListsTests
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
        public void AddUpdateRemoveListItem()
        {
            const int listId = 1;
            var testId = Guid.NewGuid().ToString("N");

            // Prepare initial list item
            var saveRequest = new SaveListItemRequest
            {
                Color = testId,
                Weight = 1,
                Name = $"Test list item: {testId}",
                ListId = listId,
                NumericValue = 1,
            };

            // Insert and assert
            var saveResponse = _apiClient.SaveListItem(saveRequest);
            AssertHelper.AssertSuccess(saveResponse);
            Assert.IsTrue(saveResponse.Value.Id != Guid.Empty, "Returned ID from insert was empty.");

            // Update and assert
            saveRequest.Id = saveResponse.Value.Id;
            saveRequest.Name = $"Update test list item: {testId}";
            saveResponse = _apiClient.SaveListItem(saveRequest);
            AssertHelper.AssertSuccess(saveResponse);
            Assert.IsTrue(saveResponse.Value.Id == saveRequest.Id, "Returned ID from update was not correct.");

            // Remove
            var deleteResponse = _apiClient.DeleteListItem(listId, saveRequest.Id.Value);
            AssertHelper.AssertSuccess(deleteResponse);
        }

        [TestMethod]
        public async Task AddUpdateRemoveListItemAsync()
        {
            const int listId = 1;
            var testId = Guid.NewGuid().ToString("N");

            // Prepare initial list item
            var saveRequest = new SaveListItemRequest
            {
                Color = testId,
                Weight = 1,
                Name = $"Test list item: {testId}",
                ListId = listId,
                NumericValue = 1,
            };

            // Insert and assert
            var saveResponse = await _apiClient.SaveListItemAsync(saveRequest);
            AssertHelper.AssertSuccess(saveResponse);
            Assert.IsTrue(saveResponse.Value.Id != Guid.Empty, "Returned ID from insert was empty.");

            // Update and assert
            saveRequest.Id = saveResponse.Value.Id;
            saveRequest.Name = $"Update test list item: {testId}";
            saveResponse = await _apiClient.SaveListItemAsync(saveRequest);
            AssertHelper.AssertSuccess(saveResponse);
            Assert.IsTrue(saveResponse.Value.Id == saveRequest.Id, "Returned ID from update was not correct.");

            // Remove
            var deleteResponse = await _apiClient.DeleteListItemAsync(listId, saveRequest.Id.Value);
            AssertHelper.AssertSuccess(deleteResponse);
        }
    }
}
