using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileWithNameRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        string Name { get; }
        IAddFileWithStreamRequestBuilder WithStream(Stream stream);
    }
}