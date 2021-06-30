namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a report associated to an app.
    /// </summary>
    public class GetReportByApp
    {
        /// <summary>
        /// Report's primary app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Report identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the report.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the report.
        /// </summary>
        public string Description { get; set; }
    }
}
