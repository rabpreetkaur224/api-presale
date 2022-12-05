using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class ImageDump
    {
        public int ImageId { get; set; }
        public string ImageFileName { get; set; }
        public string ImageActualFileName { get; set; }
        public string FolderName { get; set; }
        public string FilePath { get; set; }
        public int Type { get; set; }
        public int? MaterId { get; set; }
        public bool IsPrimary { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsVideoImage { get; set; }
        public bool IsVideo { get; set; }
    }
}
