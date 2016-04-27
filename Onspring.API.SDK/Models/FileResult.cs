#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  * <<FULL COPYRIGHT PENDING>>
//  *  
// */
#endregion

using System;
using System.IO;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Onspring.API.SDK.Models
{
    public class FileResult: IDisposable
    {
        public FileResult()
        {
            Stream = new MemoryStream();
        }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public MemoryStream Stream { get; }

        public void Dispose()
        {
            Stream.Dispose();
        }
    }
}
