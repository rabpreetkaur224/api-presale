using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class ProductInquiry
    {
        public int ProductInquiryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PriceRange { get; set; }
        public string Bedrooms { get; set; }
        public bool IsRealtor { get; set; }
        public bool IsAgent { get; set; }
        public int ProductId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
