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
    public class AddEditResult
    {
        public AddEditResult()
        {
            Warnings = new List<string>();
        }

        public string Location { get; set; }

        public int? CreatedId { get; set; }

        public IReadOnlyList<string> Warnings { get; set; }
    }
}
