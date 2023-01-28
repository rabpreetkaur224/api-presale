namespace PresaleApi.Models
{
    public class CmsResponse
    {
        public int CmsId { get; set; }
        public string CmsTitle { get; set; }
        public string CmsName { get; set; }
        public bool IsActive { get; set; }
        public string CmsBody { get; set; }
        public string Url { get; set; }
    }
}
