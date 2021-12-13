namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a response to creating a resource that returns an identifier.
    /// </summary>
    public class CreatedWithIdResponse<T>
    {
        /// <summary>
        /// Identifier returned.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="CreatedWithIdResponse{T}"/>.
        /// </summary>
        public CreatedWithIdResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CreatedWithIdResponse{T}"/>.
        /// </summary>
        /// <param name="id"></param>
        public CreatedWithIdResponse(T id)
        {
            Id = id;
        }
    }
}
