namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder interface for creating various types of Onspring API requests.
    /// </summary>
    public interface IOnspringRequestBuilder
    {
        /// <summary>
        /// Creates a builder for checking the connection to the Onspring API.
        /// </summary>
        /// <returns>A builder instance for checking the connection that implements the <see cref="IConnectionRequestBuilder"/> interface.</returns>
        IConnectionRequestBuilder ToCheckConnection();

        /// <summary>
        /// Creates a builder for retrieving records from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving records that implements the <see cref="IGetRecordsRequestBuilder"/> interface.</returns>
        IGetRecordsRequestBuilder ToGetRecords();

        /// <summary>
        /// Creates a builder for deleting records in Onspring.
        /// </summary>
        /// <returns>A builder instance for deleting records that implements the <see cref="IDeleteRecordsRequestBuilder"/> interface.</returns>
        IDeleteRecordsRequestBuilder ToDeleteRecords();

        /// <summary>
        /// Creates a builder for saving a record in Onspring.
        /// </summary>
        /// <returns>A builder instance for saving records that implements the <see cref="ISaveRecordRequestBuilder"/> interface.</returns>
        ISaveRecordRequestBuilder ToSaveRecord();

        /// <summary>
        /// Creates a builder for retrieving reports from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving reports that implements the <see cref="IGetReportsRequestBuilder"/> interface.</returns>
        IGetReportsByAppRequestBuilder ToGetReports();

        /// <summary>
        /// Creates a builder for retrieving report data from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving report data that implements the <see cref="IGetReportRequestBuilder"/> interface.</returns>
        IGetReportRequestBuilder ToGetReportData();

        /// <summary>
        /// Creates a builder for saving a list value in Onspring.
        /// </summary>
        /// <returns>A builder instance for saving list values that implements the <see cref="ISaveListValueRequestBuilder"/> interface.</returns>
        ISaveListValueRequestBuilder ToSaveListValue();

        /// <summary>
        /// Creates a builder for deleting a list value in Onspring.
        /// </summary>
        /// <returns>A builder instance for deleting list values that implements the <see cref="IDeleteListValueRequestBuilder"/> interface.</returns>
        IDeleteListValueRequestBuilder ToDeleteListValue();

        /// <summary>
        /// Creates a builder for retrieving files from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving files that implements the <see cref="IGetFileRequestBuilder"/> interface.</returns>
        IGetFileRequestBuilder ToGetFile();

        /// <summary>
        /// Creates a builder for retrieving file information from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving file information that implements the <see cref="IGetFileInfoRequestBuilder"/> interface.</returns>
        IGetFileInfoRequestBuilder ToGetFileInfo();

        /// <summary>
        /// Creates a builder for deleting a file in Onspring.
        /// </summary>
        /// <returns>A builder instance for deleting files that implements the <see cref="IDeleteFileRequestBuilder"/> interface.</returns>
        IDeleteFileRequestBuilder ToDeleteFile();

        /// <summary>
        /// Creates a builder for adding a file in Onspring.
        /// </summary>
        /// <returns>A builder instance for adding files that implements the <see cref="IAddFileRequestBuilder"/> interface.</returns>
        IAddFileRequestBuilder ToAddFile();

        /// <summary>
        /// Creates a builder for retrieving fields from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving fields that implements the <see cref="IGetFieldsRequestBuilder"/> interface.</returns>
        IGetFieldsRequestBuilder ToGetFields();

        /// <summary>
        /// Creates a builder for retrieving apps from Onspring.
        /// </summary>
        /// <returns>A builder instance for retrieving apps that implements the <see cref="IGetAppsRequestBuilder"/> interface.</returns>
        IGetAppsRequestBuilder ToGetApps();
    }
}