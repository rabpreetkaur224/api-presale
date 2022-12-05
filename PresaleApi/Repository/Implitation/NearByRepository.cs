using Microsoft.EntityFrameworkCore;
using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class NearByRepository : INearByRepository
    {
        private readonly PresaleContext _dbContext;
        public NearByRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(NearBy model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.NearById > 0)
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
        public List<NearBy> List()
        {
            var list = _dbContext.NearBy.ToList();
            return list;
        }
        public NearBy Detail(int id)
        {
            var nearBy = _dbContext.NearBy.FirstOrDefault(x => x.NearById == id);
            return nearBy;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var nearBy = _dbContext.NearBy.FirstOrDefault(x => x.NearById == id);
            _dbContext.Remove(nearBy);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
