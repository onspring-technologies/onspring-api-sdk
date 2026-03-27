namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents options for building requests to get all pages of reports for a specific app.
    /// </summary>
    public class GetAllReportsPagesByAppRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the page size for the request. Default is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}