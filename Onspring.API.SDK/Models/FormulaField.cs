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

namespace Onspring.API.SDK.Models
{
    public class FormulaField: Field
    {
        public FormulaOutputType OutputType { get; set; }
        public IReadOnlyList<ListValue> Values { get; set; }
    }
}