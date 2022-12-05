using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public int? ParentCategoryId { get; set; }
        public Guid? ImageId { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string ImageName { get; set; }
        public bool ShowInMenu { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
