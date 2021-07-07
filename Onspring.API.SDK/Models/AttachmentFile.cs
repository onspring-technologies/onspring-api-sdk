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
    public class AttachmentFile
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public FileStorageSite StorageLocation { get; set; }
        public string DownloadLink { get; set; }
        public string QuickEditLink { get; set; }
    }
}
