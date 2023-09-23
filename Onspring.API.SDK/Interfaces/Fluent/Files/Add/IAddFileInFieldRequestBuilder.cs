namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileInFieldRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        IAddFileWithNameRequestBuilder WithName(string name);
    }
}