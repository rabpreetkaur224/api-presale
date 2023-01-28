namespace PresaleApi.Models
{
    public class TypedProductListRequest
    {
        public bool IsArrival { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public bool IsShowOnHomePage { get; set; }
        public bool IsUpComing { get; set; }
    }
}
