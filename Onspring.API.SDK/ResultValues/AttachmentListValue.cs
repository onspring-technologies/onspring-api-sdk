#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class AttachmentListValue: ResultValue
    {
        public AttachmentListValue(IReadOnlyList<AttachmentFile> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.AttachmentList;

        public IReadOnlyList<AttachmentFile> Value { get; private set; }

    }

}