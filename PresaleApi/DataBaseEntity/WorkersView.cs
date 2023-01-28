using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class WorkersView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateIds { get; set; }
        public int? Salary { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public Guid? UpdateBy { get; set; }
        public string States { get; set; }
    }
}
