#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a report associated to an app.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Report's primary app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Report identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the report.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the report.
        /// </summary>
        public string Description { get; set; }
    }
}