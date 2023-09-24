namespace Onspring.API.SDK.Interfaces.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file to a field.
    /// </summary>
    public interface IAddFileInFieldRequestBuilder
    {
        /// <summary>
        /// Gets the ID of the record to add the file to.
        /// </summary>
        int RecordId { get; }

        /// <summary>
        /// Gets the ID of the field to add the file to.
        /// </summary>
        int FieldId { get; }

        /// <summary>
        /// Specifies the name of the file to add.
        /// </summary>
        /// <param name="name">The name of the file to add.</param>
        /// <returns>A <see cref="IAddFileWithNameRequestBuilder"/> for further configuration of the request.</returns>
        IAddFileWithNameRequestBuilder WithName(string name);
    }
}