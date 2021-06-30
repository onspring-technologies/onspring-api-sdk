using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Extensions
{
    /// <summary>
    /// Extensions around <see cref="PagingRequest"/>.
    /// </summary>
    internal static class PagingRequestExtensions
    {
        /// <summary>
        /// Converts the <paramref name="pagingRequest"/> into a query string (minus ?).
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>PageNumber=1&PageSize=50</returns>
        public static string ToQueryStringParams(this PagingRequest pagingRequest)
        {
            if (pagingRequest == null)
            {
                return "";
            }

            return $"{nameof(pagingRequest.PageNumber)}={pagingRequest.PageNumber}&{nameof(pagingRequest.PageSize)}={pagingRequest.PageSize}";
        }
    }
}
