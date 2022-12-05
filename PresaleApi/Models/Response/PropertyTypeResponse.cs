namespace PresaleApi.Models
{
    public class PropertyTypeResponse :BaseResponse
    {
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
