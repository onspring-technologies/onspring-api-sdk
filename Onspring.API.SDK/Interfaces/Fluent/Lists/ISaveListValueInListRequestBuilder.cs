using System;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface ISaveListValueInListRequestBuilder
    {
        ISaveListValueWithIdRequestBuilder WithId(Guid? id);
    }
}