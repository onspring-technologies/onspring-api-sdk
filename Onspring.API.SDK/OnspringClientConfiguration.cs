using Onspring.API.SDK.Validation;
using System;

namespace Onspring.API.SDK
{
    /// <summary>
    /// Configuration for the <see cref="OnspringClient"/>.
    /// </summary>
    public class OnspringClientConfiguration
    {
        /// <summary>
        /// Gets or sets the base address of the client.
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// Gets or sets the API Key used for authentication.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="OnspringClientConfiguration"/>.
        /// </summary>
        public OnspringClientConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="OnspringClientConfiguration"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when <paramref name="apiKey"/> or <paramref name="baseAddress"/> is invalid</exception>
        public OnspringClientConfiguration(string baseAddress, string apiKey)
        {
            Arg.IsNotNullOrWhitespace(baseAddress, nameof(baseAddress));
            Arg.IsValidUrl(baseAddress, nameof(baseAddress));

            Arg.IsNotNullOrWhitespace(apiKey, nameof(apiKey));

            BaseAddress = baseAddress;
            ApiKey = apiKey;
        }
    }
}
