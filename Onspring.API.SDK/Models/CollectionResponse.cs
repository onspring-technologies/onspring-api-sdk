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
    /// <summary>
    /// Represents the base class for a response containing a collection
    /// of items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionResponse<T>
    {
        /// <summary>
        /// Total count of items in the response.
        /// </summary>
        public int Count => Items?.Count ?? 0;

        /// <summary>
        /// Collection of items.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Initializes a new instance of the response.
        /// </summary>
        public CollectionResponse()
        {
        }
    }
}
