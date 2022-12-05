using System;

namespace PresaleApi.Models
{
    public class TestimonialRequest : BaseResponse
    {
        public int TestimonialId { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialName { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public string TestimonialBody { get; set; }
        public string Url { get; set; }
   
    }
}
