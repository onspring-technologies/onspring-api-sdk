using System;
using System.IO;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileWithNotesRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        string Name { get; }
        Stream FileStream { get; }
        string Type { get; }
        string Notes { get; }
        IAddFileWithModifiedDateRequestBuilder WithModifiedDate(DateTime? modifiedDate);
    }
}