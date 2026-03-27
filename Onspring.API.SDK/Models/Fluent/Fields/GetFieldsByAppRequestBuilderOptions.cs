namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents the options for a request to retrieve fields by app.
    /// </summary>
    public class GetFieldsByAppRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the page number to retrieve. The default is 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size to retrieve. The default is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}