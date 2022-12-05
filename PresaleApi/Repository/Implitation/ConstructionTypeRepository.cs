using PresaleApi.DataBaseEntity;
using PresaleApi.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class ConstructionTypeRepository : IConstructionTypeRepository
    {
        private readonly PresaleContext _dbContext;
        public ConstructionTypeRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(ConstructionType model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.ConstructionTypeId > 0)
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
        public List<ConstructionType> List()
        {
            var list = _dbContext.ConstructionType.ToList();
            return list;
        }
        public ConstructionType Detail(int id)
        {
            var ConstructionType = _dbContext.ConstructionType.FirstOrDefault(x => x.ConstructionTypeId == id);
            return ConstructionType;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var ConstructionType = _dbContext.ConstructionType.FirstOrDefault(x => x.ConstructionTypeId == id);
            _dbContext.Remove(ConstructionType);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
