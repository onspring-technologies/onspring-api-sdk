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
    /// Represents a response to request that has paged items.
    /// </summary>
    public class PagedResponse<T>
    {
        /// <summary>
        /// Gets the page number of the response.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        public int PageSize => Items?.Count ?? 0;

        /// <summary>
        /// Gets the total amount of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets the total amount of records.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Gets the collection of items in the response.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();
    }
}
