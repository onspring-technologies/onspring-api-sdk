using System;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a list value in a list.
    /// </summary>
    public interface IDeleteListValueInListRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the list to delete the value in.
        /// </summary>
        int ListId { get; }

        /// <summary>
        /// Specifies the ID of the list value to delete.
        /// </summary>
        /// <param name="id">The ID of the list value to delete.</param>
        /// <returns>A <see cref="IDeleteListValueWithIdRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteListValueWithIdRequestBuilder WithId(Guid id);
    }
}