using Newtonsoft.Json;
using Onspring.API.SDK.Internals;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Extensions
{
    /// <summary>
    /// Extensions around <see cref="HttpClient"/>.
    /// </summary>
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// Performs an HTTP Get to the <paramref name="path"/>, using the <paramref name="apiKey"/> as a header.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="path"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string path, string apiKey)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Add(ApiHeaderConstants.ApiKeyName, apiKey);

            return httpClient.SendAsync(request);
        }

        /// <summary>
        /// Performs an HTTP Delete to the <paramref name="path"/>, using the <paramref name="apiKey"/> as a header.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="path"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string path, string apiKey)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, path);
            request.Headers.Add(ApiHeaderConstants.ApiKeyName, apiKey);

            return httpClient.SendAsync(request);
        }

        /// <summary>
        /// Performs an HTTP Post to the <paramref name="path"/>, using the <paramref name="apiKey"/> as a header and the <paramref name="path"/> as the body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="path"></param>
        /// <param name="apiKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient httpClient, string path, string apiKey, T content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Headers.Add(ApiHeaderConstants.ApiKeyName, apiKey);

            var json = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = httpContent;

            return httpClient.SendAsync(request);
        }

        /// <summary>
        /// Performs an HTTP Put to the <paramref name="path"/>, using the <paramref name="apiKey"/> as a header and the <paramref name="path"/> as the body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="path"></param>
        /// <param name="apiKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient httpClient, string path, string apiKey, T content)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, path);
            request.Headers.Add(ApiHeaderConstants.ApiKeyName, apiKey);

            var json = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = httpContent;

            return httpClient.SendAsync(request);
        }
    }
}
