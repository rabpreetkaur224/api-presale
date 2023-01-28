using System;

namespace PresaleApi.Models
{
    public class TeachersRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SubjectIds { get; set; }
        public int? Salary { get; set; }

    }
}
