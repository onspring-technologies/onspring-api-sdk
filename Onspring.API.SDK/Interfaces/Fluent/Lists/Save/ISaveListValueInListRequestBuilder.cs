using System;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a list value in a list.
    /// </summary>
    public interface ISaveListValueInListRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the list to save the value in. If id is null, a new list value will be created.
        /// </summary>
        /// <param name="id">The ID of the list value to save.</param>
        /// <returns>A <see cref="ISaveListValueWithIdRequestBuilder"/> for further configuration of the request.</returns>
        ISaveListValueWithIdRequestBuilder WithId(Guid? id);
    }
}