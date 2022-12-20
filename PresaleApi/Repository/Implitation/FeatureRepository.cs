using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly PresaleContext _dbContext;
        public FeatureRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Feature model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.FeatureId > 0)
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
        public List<Feature> List()
        {
            var list = _dbContext.Feature.ToList();
            return list;
        }
        public Feature Detail(int id)
        {
            var feature = _dbContext.Feature.FirstOrDefault(x => x.FeatureId == id);
            return feature;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Feature = _dbContext.Feature.FirstOrDefault(x => x.FeatureId == id);
            _dbContext.Remove(Feature);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
