using Newtonsoft.Json;
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
        /// <param name="httpResponse"></param>
        /// <param name="jsonSerializer"></param>
        /// <returns></returns>
        public static async Task<ApiResponse> GetApiResponseAsync(HttpResponseMessage httpResponse, JsonSerializer jsonSerializer)
        {
            var message = await TryGetMessageAsync(httpResponse, jsonSerializer);

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
        /// <param name="jsonSerializer"></param>
        /// <returns></returns>
        public static async Task<ApiResponse<T>> GetApiResponseAsync<T>(HttpResponseMessage httpResponse, JsonSerializer jsonSerializer)
        {
            var message = await TryGetMessageAsync(httpResponse, jsonSerializer);

            var apiResponse = new ApiResponse<T>
            {
                Message = message,
                StatusCode = httpResponse.StatusCode,
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse.Value = await httpResponse.Content.ReadAsJsonAsync<T>(jsonSerializer);
            }

            return apiResponse;
        }

        /// <summary>
        /// Attempts to extract a message from the <paramref name="httpResponse"/>.
        /// </summary>
        /// <returns></returns>
        internal static async Task<string> TryGetMessageAsync(HttpResponseMessage httpResponse, JsonSerializer jsonSerializer)
        {
            var message = string.Empty;
            if (httpResponse.StatusCode == HttpStatusCode.Unauthorized || httpResponse.StatusCode == HttpStatusCode.Forbidden || httpResponse.StatusCode == HttpStatusCode.NotFound)
            {
                var messageResponse = await httpResponse.Content.ReadAsJsonAsync<MessageResponse>(jsonSerializer);
                message = messageResponse?.Message;
            }
            else if (httpResponse.IsSuccessStatusCode == false)
            {
                message = await httpResponse.Content.ReadAsStringAsync();
            }
            return message ?? string.Empty;
        }
    }
}
