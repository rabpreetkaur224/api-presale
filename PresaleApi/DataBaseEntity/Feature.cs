using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class Feature
    {
        public Feature()
        {
            ProductFeatureMapping = new HashSet<ProductFeatureMapping>();
        }

        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual ICollection<ProductFeatureMapping> ProductFeatureMapping { get; set; }
    }
}
