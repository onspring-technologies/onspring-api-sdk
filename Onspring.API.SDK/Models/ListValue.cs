#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System;

namespace Onspring.API.SDK.Models
{
    public class ListValue
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public decimal? NumericValue { get; set; }
        public string Color { get; set; }
    }
}