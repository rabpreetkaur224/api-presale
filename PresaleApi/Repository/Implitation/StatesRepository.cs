using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class StatesRepository : IStatesRepository
    {
        private readonly PresaleContext _dbContext;
        public StatesRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(States model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.Id > 0)
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
        public List<States> List()
        {
            var list = _dbContext.States.ToList();
            return list;
        }
        public States Detail(int id)
        {
            var States = _dbContext.States.FirstOrDefault(x => x.Id == id);
            return States;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var States = _dbContext.States.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(States);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
        public ApplicationResponse DeleteAll(List<int> ids)
        {
            ApplicationResponse returnobj = new ApplicationResponse();

            ids.ForEach(item => {
                var States = _dbContext.States.FirstOrDefault(x => x.Id == item);
                if (States != null)
                {
                    _dbContext.Remove(States);
                    _dbContext.SaveChanges();

                }
            });

            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
