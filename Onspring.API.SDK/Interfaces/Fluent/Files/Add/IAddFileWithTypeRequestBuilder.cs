using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileWithTypeRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        string Name { get; }
        Stream FileStream { get; }
        string Type { get; }
        IAddFileWithNotesRequestBuilder WithNotes(string notes);
    }
}