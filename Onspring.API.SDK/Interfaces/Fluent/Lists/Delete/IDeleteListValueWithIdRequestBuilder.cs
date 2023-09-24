using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a list value in a list.
    /// </summary>
    public interface IDeleteListValueWithIdRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the list to delete the value in.
        /// </summary>
        int ListId { get; }

        /// <summary>
        /// Gets the ID of the list value to delete.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Asynchronously sends the request to delete the list value.
        /// </summary>
        /// <returns>An awaitable task that returns an <see cref="ApiResponse"/> when complete.</returns>
        Task<ApiResponse> SendAsync();
    }
}