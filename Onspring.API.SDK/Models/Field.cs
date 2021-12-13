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
    /// <summary>
    /// Represents a field.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Field's identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Associated app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Field name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Field type.
        /// </summary>
        public FieldType Type { get; set; }

        /// <summary>
        /// Field status.
        /// </summary>
        public FieldStatus Status { get; set; }

        /// <summary>
        /// Represents if this is a required field or not.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Represents if this is a unique field or not.
        /// </summary>
        public bool IsUnique { get; set; }
    }
}