namespace PresaleApi.Models
{
    public class MarketingCompanyRequest
    {
        public int MarketingCompanyId { get; set; }
        public string MarketingCompanyName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
