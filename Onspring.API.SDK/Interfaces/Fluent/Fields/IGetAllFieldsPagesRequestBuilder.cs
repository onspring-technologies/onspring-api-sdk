namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a request builder for getting all pages of fields.
    /// </summary>
    public interface IGetAllFieldsPagesRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the app to retrieve fields for.
        /// </summary>
        /// <param name="appId">The ID of the app to retrieve fields for.</param>
        /// <returns>A <see cref="IGetAllFieldsPagesByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetAllFieldsPagesByAppRequestBuilder FromApp(int appId);
    }
}