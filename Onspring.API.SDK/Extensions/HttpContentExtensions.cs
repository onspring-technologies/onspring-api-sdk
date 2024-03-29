﻿using Newtonsoft.Json;
using Onspring.API.SDK.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Extensions
{
    /// <summary>
    /// Extensions around <see cref="HttpResponseMessage"/>.
    /// </summary>
    internal static class HttpContentExtensions
    {
        /// <summary>
        /// Reads the <paramref name="content"/> content as JSON and deserializes it into an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="jsonSerializer"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content, JsonSerializer jsonSerializer)
        {
            var serializer = jsonSerializer ?? JsonSerializerFactory.GetDefaultSerializer();

            var stream = await content.ReadAsStreamAsync();

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
