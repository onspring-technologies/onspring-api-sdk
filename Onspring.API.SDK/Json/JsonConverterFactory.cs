using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Json
{
    internal static class JsonConverterFactory
    {
        private static readonly Lazy<IReadOnlyList<JsonConverter>> _lazyConverters = new Lazy<IReadOnlyList<JsonConverter>>(GetAllJsonConverters);

        public static IReadOnlyList<JsonConverter> GetJsonConverters()
        {
            return _lazyConverters.Value;
        }

        private static IReadOnlyList<JsonConverter> GetAllJsonConverters()
        {
            return new List<JsonConverter>()
            {
                new FieldJsonConverter(),
            };
        }
    }
}
