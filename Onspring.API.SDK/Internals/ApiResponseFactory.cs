using Onspring.API.SDK.Extensions;
using Onspring.API.SDK.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Internals
{
    /// <summary>
    /// Factory used to generate <see cref="ApiResponse"/> instances.
    /// </summary>
    internal static class ApiResponseFactory
    {
        /// <summary>
        /// Generates an <see cref="ApiResponse"/> based on the <paramref name="httpResponse"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public static async Task<ApiResponse> GetApiResponseAsync(this HttpResponseMessage httpResponse)
        {
            var message = await TryGetMessageAsync(httpResponse);

            var apiResponse = new ApiResponse
            {
                Message = message,
                StatusCode = httpResponse.StatusCode,
            };

            return apiResponse;
        }

        /// <summary>
        /// Generates an <see cref="ApiResponse{T}"/> based on the <paramref name="httpResponse"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public static async Task<ApiResponse<T>> GetApiResponseAsync<T>(this HttpResponseMessage httpResponse)
        {
            var message = await TryGetMessageAsync(httpResponse);

            var apiResponse = new ApiResponse<T>
            {
                Message = message,
                StatusCode = httpResponse.StatusCode,
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse.Response = await httpResponse.Content.ReadAsJsonAsync<T>();
            }

            return apiResponse;
        }

        /// <summary>
        /// Attempts to extract a message from the <paramref name="httpResponse"/>.
        /// </summary>
        /// <returns></returns>
        internal static async Task<string> TryGetMessageAsync(HttpResponseMessage httpResponse)
        {
            var message = string.Empty;
            if (httpResponse.StatusCode == HttpStatusCode.Unauthorized || httpResponse.StatusCode == HttpStatusCode.Forbidden || httpResponse.StatusCode == HttpStatusCode.NotFound)
            {
                var messageResponse = await httpResponse.Content.ReadAsJsonAsync<MessageResponse>();
                message = messageResponse?.Message ?? message;
            }
            else if (httpResponse.IsSuccessStatusCode == false)
            {
                message = await httpResponse.Content.ReadAsStringAsync();
                message = message ?? string.Empty;
            }
            return message;
        }
    }
}
