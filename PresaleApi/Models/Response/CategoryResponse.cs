using System;

namespace PresaleApi.Models.Response
{
    public class CategoryResponse : BaseResponse
    {
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public int? ParentCategoryId { get; set; }
        public Guid? ImageId { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string ImageName { get; set; }
        public bool ShowInMenu { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }


    }
}
