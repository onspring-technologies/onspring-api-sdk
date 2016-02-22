#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System;
using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class GuidListValue: ResultValue
    {
        public GuidListValue(IReadOnlyList<Guid> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.GuidList;

        public IReadOnlyList<Guid> Value { get; private set; }

    }

}