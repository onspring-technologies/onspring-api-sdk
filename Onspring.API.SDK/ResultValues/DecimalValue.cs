#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class DecimalValue: ResultValue
    {
        public DecimalValue(decimal? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Decimal;

        public decimal? Value { get; private set; }

    }

}