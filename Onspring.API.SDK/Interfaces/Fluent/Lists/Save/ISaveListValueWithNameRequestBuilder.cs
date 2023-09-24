using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a list value with name in a list.
    /// </summary>
    public interface ISaveListValueWithNameRequestBuilder
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
        /// Gets the name of the list value to save.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Specifies the color of the list value to save.
        /// </summary>
        /// <param name="color">The color of the list value to save.</param>
        /// <returns>A <see cref="ISaveListValueWithNameRequestBuilder"/> for further configuration of the request.</returns>
        ISaveListValueWithNameRequestBuilder WithColor(string color);

        /// <summary>
        /// Specifies the numeric value of the list value to save.
        /// </summary>
        /// <param name="value">The numeric value of the list value to save.</param>
        /// <returns>A <see cref="ISaveListValueWithNameRequestBuilder"/> for further configuration of the request.</returns>
        ISaveListValueWithNameRequestBuilder WithNumericValue(decimal value);

        /// <summary>
        /// Asynchronously sends the request to save the list value.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse{SaveListItemResponse}"/> when complete.</returns>
        Task<ApiResponse<SaveListItemResponse>> SendAsync();
    }
}