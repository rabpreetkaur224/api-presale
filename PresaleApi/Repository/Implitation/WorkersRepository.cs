using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class WorkersRepository : IWorkersRepository
    {
        private readonly PresaleContext _dbContext;
        public WorkersRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Workers model)
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
        public List<WorkersView> List()
        {
            var list = _dbContext.WorkersView.ToList();
            return list;
        }
        public Workers Detail(int id)
        {
            var Workers = _dbContext.Workers.FirstOrDefault(x => x.Id == id);
            return Workers;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Workers = _dbContext.Workers.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(Workers);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
        public ApplicationResponse DeleteAll(List<int> ids)
        {
            ApplicationResponse returnobj = new ApplicationResponse();

            ids.ForEach(item =>
            {
                var Workers = _dbContext.Workers.FirstOrDefault(x => x.Id == item);
                if (Workers != null)
                {
                    _dbContext.Remove(Workers);
                    _dbContext.SaveChanges();

                }
            });

            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
