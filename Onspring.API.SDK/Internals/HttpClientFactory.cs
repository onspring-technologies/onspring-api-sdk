using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Onspring.API.SDK.Internals
{
    /// <summary>
    /// Internal factory used to managed HttpClient instances created.
    /// </summary>
    internal static class HttpClientFactory
    {
        private static readonly ConcurrentDictionary<string, HttpClient> _clientCache = new ConcurrentDictionary<string, HttpClient>();

        /// <summary>
        /// Gets an <see cref="HttpClient"/> using the provided <paramref name="baseAddress"/>.
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <returns></returns>
        public static HttpClient GetHttpClient(string baseAddress)
        {
            return _clientCache.GetOrAdd(baseAddress, (address) => new HttpClient { BaseAddress = new Uri(address) });
        }
    }
}
