using PresaleApi.DataBaseEntity;
using PresaleApi.Models;

namespace PresaleApi.Repository
{
    public interface  ITestimonialRepository
    {
         ApplicationResponse Upsert(Testimonial model);
    }
}
