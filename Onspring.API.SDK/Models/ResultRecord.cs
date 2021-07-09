#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion

using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class ResultRecord
    {
        public int AppId { get; set; }
        public int RecordId { get; set; }
        public List<RecordFieldValue> FieldData { get; set; } = new List<RecordFieldValue>();
    }
}