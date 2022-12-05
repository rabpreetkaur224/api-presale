using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsShowOnHomePage { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public bool IsArrival { get; set; }
        public bool IsUpComing { get; set; }
        public string Url { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int DisplayOrder { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SubName { get; set; }
        public int? LocationId { get; set; }
        public int? SubLocationId { get; set; }
        public string Address { get; set; }
        public int? YearOfCompletion { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public int? Floors { get; set; }
        public int? Units { get; set; }
        public string GoogleAddressIfram { get; set; }
    }
}
