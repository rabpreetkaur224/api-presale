using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class MarketingCompany
    {
        public MarketingCompany()
        {
            ProductMarketingCompanyMapping = new HashSet<ProductMarketingCompanyMapping>();
        }

        public int MarketingCompanyId { get; set; }
        public string MarketingCompanyName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual ICollection<ProductMarketingCompanyMapping> ProductMarketingCompanyMapping { get; set; }
    }
}
