using System;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface ISaveListValueWithIdRequestBuilder
    {
        int ListId { get; }
        Guid? Id { get; }
        ISaveListValueWithNameRequestBuilder WithName(string name);
    }
}