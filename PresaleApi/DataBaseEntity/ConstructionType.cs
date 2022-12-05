using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class ConstructionType
    {
        public ConstructionType()
        {
            ProductConstructionTypeMapping = new HashSet<ProductConstructionTypeMapping>();
        }

        public int ConstructionTypeId { get; set; }
        public string ConstructionTypeName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual ICollection<ProductConstructionTypeMapping> ProductConstructionTypeMapping { get; set; }
    }
}
