using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class ProductDeveloperMappingView
    {
        public string DeveloperName { get; set; }
        public int ProductId { get; set; }
        public int ProductDeveloperMappingId { get; set; }
    }
}
