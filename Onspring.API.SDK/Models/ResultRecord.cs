﻿#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
namespace Onspring.API.SDK.Models
{
    public class ResultRecord
    {
        public ResultRecord()
        {
            Values = new FieldValueContainer();
        }

        public int AppId { get; set; }
        public int RecordId { get; set; }
        public FieldValueContainer Values { get; private set; }

    }
}