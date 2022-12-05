using PresaleApi.DataBaseEntity;

namespace PresaleApi.Repository
{
    public class MarketingCompanyRepository
    {
        private readonly PresaleContext _dbContext;
        public MarketingCompanyRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(MarketingCompany model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.MarketingCompanyId > 0)
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
