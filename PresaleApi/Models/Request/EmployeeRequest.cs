﻿namespace PresaleApi.Models
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? DepartmentId { get; set; }
        public int Salary { get; set; }

    }
}
