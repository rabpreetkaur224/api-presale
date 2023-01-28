namespace PresaleApi.Models
{
    public class ContactUsResponse
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsRealtor { get; set; }
        public string Message { get; set; }
    }
}
