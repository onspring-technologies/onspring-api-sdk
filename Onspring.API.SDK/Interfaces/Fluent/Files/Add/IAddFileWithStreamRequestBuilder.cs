using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileWithStreamRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        string Name { get; }
        Stream FileStream { get; }
        IAddFileWithTypeRequestBuilder WithType(string type);
    }
}