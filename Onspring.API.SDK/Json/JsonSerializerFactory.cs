using Newtonsoft.Json;
using System;

namespace Onspring.API.SDK.Json
{
    /// <summary>
    /// Factory used to generate <see cref="JsonSerializer"/> instances.
    /// </summary>
    internal static class JsonSerializerFactory
    {
        private static readonly Lazy<JsonSerializer> _lazySerializer = new Lazy<JsonSerializer>(GetSerializer);

        /// <summary>
        /// Gets the default <see cref="JsonSerializer"/>.
        /// </summary>
        /// <returns></returns>
        public static JsonSerializer GetDefaultSerializer()
        {
            return _lazySerializer.Value;
        }

        /// <summary>
        /// Private function to get the serializer and its converters.
        /// </summary>
        /// <returns></returns>
        private static JsonSerializer GetSerializer()
        {
            var serializer = new JsonSerializer();

            serializer.Converters.Add(new FieldJsonConverter());

            return serializer;
        }
    }
}
