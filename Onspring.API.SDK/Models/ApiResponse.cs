using System.Net;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a response from the API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// Gets the actual response value, if any.
        /// </summary>
        public T Response { get; set; }
    }

    /// <summary>
    /// Represents a response from the API.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets a value indicating if the request was successful or not.
        /// </summary>
        public bool IsSuccessful => (int)StatusCode < 400;

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets the message associated to the response, if any.
        /// </summary>
        public string Message { get; set; }
    }
}
