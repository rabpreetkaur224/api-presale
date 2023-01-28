namespace PresaleApi.Models
{
    public class WorkersRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateIds { get; set; }
        public int? Salary { get; set; }
    }
}
