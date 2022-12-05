using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class ProductRelatedMapping
    {
        public int ProductRelatedMappingId { get; set; }
        public int ProductId { get; set; }
        public int RelatedProductId { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
