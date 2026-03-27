namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents the options for a request to get reports.
    /// </summary>
    public class GetReportsRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the page number to retrieve.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size to retrieve.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}