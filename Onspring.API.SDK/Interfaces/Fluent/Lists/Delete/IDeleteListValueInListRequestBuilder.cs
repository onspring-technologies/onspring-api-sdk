using System;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteListValueInListRequestBuilder
    {
        int ListId { get; }
        IDeleteListValueWithIdRequestBuilder WithId(Guid id);
    }
}