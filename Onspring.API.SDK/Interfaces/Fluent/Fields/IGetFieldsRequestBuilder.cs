using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve fields.
    /// </summary>
    public interface IGetFieldsRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the field to retrieve.
        /// </summary>
        /// <param name="fieldId">The ID of the field to retrieve.</param>
        /// <returns>A <see cref="IGetFieldByIdRequestBuilder"/> for further configuration of the request.</returns>
        IGetFieldByIdRequestBuilder WithId(int fieldId);

        /// <summary>
        /// Specifies the ID of the app to retrieve fields for.
        /// </summary>
        /// <param name="appId">The ID of the app to retrieve fields for.</param>
        /// <returns>A <see cref="IGetFieldsByAppRequestBuilder"/> for further configuration of the request.</returns>
        IGetFieldsByAppRequestBuilder FromApp(int appId);

        /// <summary>
        /// Specifies the IDs of the fields to retrieve.
        /// </summary>
        /// <param name="fieldIds">The IDs of the fields to retrieve.</param>
        /// <returns>A <see cref="IGetFieldsByIdsRequestBuilder"/> for further configuration of the request.</returns>
        IGetFieldsByIdsRequestBuilder WithIds(IEnumerable<int> fieldIds);
    }
}