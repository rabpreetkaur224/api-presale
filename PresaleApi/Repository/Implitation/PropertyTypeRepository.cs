using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly PresaleContext _dbContext;
        public PropertyTypeRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(PropertyType model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.PropertyTypeId > 0)
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
        public List<PropertyType> List()
        {
            var list = _dbContext.PropertyType.ToList();
            return list;
        }
        public PropertyType Detail(int id)
        {
            var PropertyType = _dbContext.PropertyType.FirstOrDefault(x => x.PropertyTypeId == id);
            return PropertyType;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var PropertyType = _dbContext.PropertyType.FirstOrDefault(x => x.PropertyTypeId == id);
            _dbContext.Remove(PropertyType);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }

       
    }
}
