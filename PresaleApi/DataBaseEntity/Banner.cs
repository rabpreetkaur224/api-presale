using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class Banner
    {
        public int BannerId { get; set; }
        public int BannerType { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public int? CategoryId { get; set; }
    }
}
