namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to save a list value.
    /// </summary>
    public interface ISaveListValueRequestBuilder
    {
        /// <summary>
        /// Specifies the ID of the list to save the value in.
        /// </summary>
        /// <param name="listId">The ID of the list to save the value in.</param>
        /// <returns>A <see cref="ISaveListValueInListRequestBuilder"/> for further configuration of the request.</returns>
        ISaveListValueInListRequestBuilder InList(int listId);
    }
}