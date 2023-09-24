namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a list value.
    /// </summary>
    public interface IDeleteListValueRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the list where the list value to delete is located.
        /// </summary>
        /// <param name="listId">The ID of the list where the list value to delete is located.</param>
        /// <returns>A <see cref="IDeleteListValueInListRequestBuilder"/> for further configuration of the request.</returns>
        IDeleteListValueInListRequestBuilder InList(int listId);
    }
}