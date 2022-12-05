using System;
using System.ComponentModel.DataAnnotations;
namespace PresaleApi.Models
{
    public class ConstructionTypeRequest : BaseResponse
    {
        public int ConstructionTypeId { get; set; }
        public string ConstructionTypeName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
