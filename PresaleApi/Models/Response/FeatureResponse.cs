using System;

namespace PresaleApi.Models
{
    public class FeatureResponse:BaseResponse
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
