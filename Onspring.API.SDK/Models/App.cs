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
    /// Represents an app.
    /// </summary>
    public class App
    {
        /// <summary>
        /// URI of the application.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// App identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the app.
        /// </summary>
        public string Name { get; set; }
    }
}