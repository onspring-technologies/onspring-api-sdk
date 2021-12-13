using System;

namespace Onspring.API.SDK.Validation
{
    /// <summary>
    /// Argument validator.
    /// </summary>
    internal static class Arg
    {
        /// <summary>
        /// Validates the <paramref name="value"/> is not null.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="argName"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
        public static void IsNotNull(object value, string argName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        /// <summary>
        /// Validates the <paramref name="value"/> is not null/empty/whitespace.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="argName"></param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null/empty/whitespace.</exception>
        public static void IsNotNullOrWhitespace(string value, string argName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{argName} cannot be null/empty/whitespace.", argName);
            }
        }

        /// <summary>
        /// Validates the <paramref name="value"/> is a absolute and well-formed URI.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="argName"></param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is invalid.</exception>
        public static void IsValidUrl(string value, string argName)
        {
            if (Uri.IsWellFormedUriString(value, UriKind.Absolute) == false)
            {
                throw new ArgumentException($"{argName} must be an absolute and well-formed URI.", argName);
            }
        }
    }
}
