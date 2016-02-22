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
    public class ReportData
    {
        public IReadOnlyList<string> Columns { get; set; }
        public IReadOnlyList<ReportDataRow> Rows { get; set; }
    }
}