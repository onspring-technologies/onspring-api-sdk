namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request for a paged resource.
    /// </summary>
    public class PagingRequest
    {
        /// <summary>
        /// Page number being requested.
        /// Default value is 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Count of items requested in the page.
        /// Default value is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// Initializes a new instance of <see cref="PagingRequest"/>.
        /// </summary>
        public PagingRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PagingRequest"/>.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagingRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
