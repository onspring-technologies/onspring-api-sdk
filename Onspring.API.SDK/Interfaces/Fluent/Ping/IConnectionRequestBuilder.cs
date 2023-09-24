using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder interface for sending a connection request to the Onspring API.
    /// </summary>
    public interface IConnectionRequestBuilder
    {
        /// <summary>
        /// Asynchronously sends the connection request to the Onspring API.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a boolean indicating the success of the connection.</returns>
        Task<bool> SendAsync();
    }
}