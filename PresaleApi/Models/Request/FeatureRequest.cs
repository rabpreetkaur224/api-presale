using System;
using System.ComponentModel.DataAnnotations;

namespace PresaleApi.Models
{
    public class FeatureRequest
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
