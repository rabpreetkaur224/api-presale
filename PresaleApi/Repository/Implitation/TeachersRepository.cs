using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly PresaleContext _dbContext;
        public TeachersRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Teachers model)
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
        public List<TeacherView> List()
        {
            var list = _dbContext.TeacherView.ToList();
            return list;
        }
        public Teachers Detail(int id)
        {
            var Teachers = _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
            return Teachers;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Teachers = _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(Teachers);
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
                var Teachers = _dbContext.Teachers.FirstOrDefault(x => x.Id == item);
                if (Teachers != null)
                {
                    _dbContext.Remove(Teachers);
                    _dbContext.SaveChanges();

                }
            });

            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
