namespace PresaleApi.Models
{
    public class TeachersResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SubjectIds { get; set; }
        public int? Salary { get; set; }
        public string Subjects { get; set; }
    }
}
