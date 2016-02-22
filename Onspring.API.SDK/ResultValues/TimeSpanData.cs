#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class TimeSpanData
    {
        public int Quantity { get; set; }

        public TimeSpanIncrement Increment { get; set; }

        public TimeSpanRecurrenceType Recurrence { get; set; }

        public DateTime? EndByDate { get; set; }

        public int? EndAfterOccurrences { get; set; }

    }

}