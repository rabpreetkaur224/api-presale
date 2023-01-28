namespace PresaleApi.Models
{
    public class ProductInquiryResponse
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
    }
}
