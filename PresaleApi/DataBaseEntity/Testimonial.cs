using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class Testimonial
    {
        public int TestimonialId { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialName { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public string TestimonialBody { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
