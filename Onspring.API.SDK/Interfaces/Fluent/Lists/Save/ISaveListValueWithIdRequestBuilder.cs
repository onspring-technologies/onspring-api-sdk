using System;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a list value with id in a list.
    /// </summary>
    public interface ISaveListValueWithIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the list to save the value in.
        /// </summary>
        int ListId { get; }

        /// <summary>
        /// Gets the ID of the list value to save.
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        /// Specifies the name of the list value to save.
        /// </summary>
        /// <param name="name">The name of the list value to save.</param>
        /// <returns>A <see cref="ISaveListValueWithNameRequestBuilder"/> for further configuration of the request.</returns>
        ISaveListValueWithNameRequestBuilder WithName(string name);
    }
}