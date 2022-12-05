using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class ProductBedroomMapping
    {
        public int ProductBedroomMappingId { get; set; }
        public int ProductId { get; set; }
        public int BedroomId { get; set; }

        public virtual Bedroom Bedroom { get; set; }
    }
}
