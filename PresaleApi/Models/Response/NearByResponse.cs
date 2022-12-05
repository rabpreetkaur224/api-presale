namespace PresaleApi.Models
{
    public class NearByResponse: BaseResponse
    {
        public int NearById { get; set; }
        public string NearByName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
