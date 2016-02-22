#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string Name { get; set; }
        public FieldType Type { get; set; }
        public FieldStatus Status { get; set; }
        public bool IsRequired { get; set; }
        public bool IsUnique { get; set; }
    }
}