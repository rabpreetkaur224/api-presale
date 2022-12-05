using Microsoft.AspNetCore.Http;

namespace PresaleApi.Models
{
    public class StudentRequest
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
