using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class CmsRepository : ICmsRepository
    {
        private readonly PresaleContext _dbContext;
        public CmsRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Cms model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.CmsId > 0)
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
        public List<Cms> List()
        {
            var list = _dbContext.Cms.ToList();
            return list;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Cms = _dbContext.Cms.FirstOrDefault(x => x.CmsId == id);
            _dbContext.Remove(Cms);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
