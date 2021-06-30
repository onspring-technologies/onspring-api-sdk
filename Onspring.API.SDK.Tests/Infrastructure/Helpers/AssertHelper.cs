using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;

namespace Onspring.API.SDK.Tests.Infrastructure.Helpers
{
    [ExcludeFromCodeCoverage]
    internal static class AssertHelper
    {
        public static void AssertSuccess<T>(ApiResponse<T> apiResponse)
        {
            Assert.IsNotNull(apiResponse, "ApiResponse was null.");
            Assert.IsTrue(apiResponse.IsSuccessful, $"ApiResponse.IsSuccessful was false. Response code: {apiResponse.StatusCode}; Message: {apiResponse.Message ?? "None"}");
            Assert.IsNotNull(apiResponse.Value, "ApiResponse.Value was null.");
        }

        public static void AssertSuccess(ApiResponse apiResponse)
        {
            Assert.IsNotNull(apiResponse, "ApiResponse was null.");
            Assert.IsTrue(apiResponse.IsSuccessful, $"ApiResponse.IsSuccessful was false. Response code: {apiResponse.StatusCode}; Message: {apiResponse.Message ?? "None"}");
        }

        public static void AssertError(ApiResponse apiResponse, HttpStatusCode expectedStatusCode, bool shouldHaveMessage = false)
        {
            Assert.IsNotNull(apiResponse, "ApiResponse was null.");
            Assert.IsFalse(apiResponse.IsSuccessful, $"ApiResponse.IsSuccessful was true. Response code: {apiResponse.StatusCode}; Message: {apiResponse.Message ?? "None"}");
            Assert.AreEqual(apiResponse.StatusCode, expectedStatusCode, "ApiResponse.StatusCode was expected.");

            if (shouldHaveMessage)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(apiResponse.Message), "ApiResponse.Message was expected to contain a value.");
            }
        }

        public static void AssertPaging<T>(PagingRequest pagingRequest, PagedResponse<T> pagedResponse)
        {
            Assert.AreEqual(pagedResponse.PageNumber, pagingRequest.PageNumber, "Page number was wrong.");
            Assert.IsTrue(pagedResponse.PageSize <= pagingRequest.PageSize, "Too many returned");

            if (pagedResponse.Items.Any())
            {
                Assert.IsTrue(pagedResponse.TotalRecords > 0, "Record total value was incorrect.");
                Assert.IsTrue(pagedResponse.TotalPages > 0, "Page total value was incorrect.");
                Assert.IsTrue(pagedResponse.PageSize > 0, "Page size value was incorrect.");
            }
            else
            {
                Assert.IsTrue(pagedResponse.TotalRecords == 0, "Record total value was incorrect.");
                Assert.IsTrue(pagedResponse.TotalPages == 0, "Page total value was incorrect.");
                Assert.IsTrue(pagedResponse.PageSize == 0, "Page size value was incorrect.");
            }
        }
    }
}
