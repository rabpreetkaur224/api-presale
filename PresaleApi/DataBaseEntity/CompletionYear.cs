using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi.DataBaseEntity
{
    public partial class CompletionYear
    {
        public int CompletionYearId { get; set; }
        public string CompletionYear1 { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public Guid? UpdateBy { get; set; }
    }
}
