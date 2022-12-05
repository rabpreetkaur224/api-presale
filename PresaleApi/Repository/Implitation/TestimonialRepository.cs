using PresaleApi.DataBaseEntity;
using PresaleApi.Repository;

namespace PresaleApi.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly PresaleContext _dbContext;
        public TestimonialRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Testimonial model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.TestimonialId > 0)
            {
                _dbContext.Update(model);
                _dbContext.SaveChanges();

            }
            else
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }
            returnobj.Success = true;
            returnobj.Message = "Data Saved Successfully";
            return returnobj;
        }

    }
}
