using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly PresaleContext _dbContext;
        public SubjectRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Subject model)
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
        public List<Subject> List()
        {
            var list = _dbContext.Subject.ToList();
            return list;
        }
        public Subject Detail(int id)
        {
            var Subject = _dbContext.Subject.FirstOrDefault(x => x.Id == id);
            return Subject;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Subject = _dbContext.Subject.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(Subject);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
        public ApplicationResponse DeleteAll(List<int> ids)
        {
            ApplicationResponse returnobj = new ApplicationResponse();

            ids.ForEach(item => {
                var Subject = _dbContext.Subject.FirstOrDefault(x => x.Id == item);
                if (Subject != null)
                {
                    _dbContext.Remove(Subject);
                    _dbContext.SaveChanges();

                }
            });

            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
