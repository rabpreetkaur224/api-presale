namespace PresaleApi.Models
{
    public class StudentsResponse : BaseResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public int? Fees { get; set; }
        public int? Marks { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
    }
}
