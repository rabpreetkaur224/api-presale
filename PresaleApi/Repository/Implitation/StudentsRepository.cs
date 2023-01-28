using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly PresaleContext _dbContext;
        public StudentsRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Students model)
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
        public List<StudentsResponse> List()
        {
            //var list = _dbContext.Students.ToList();
            var result = from person in _dbContext.Students
                         join state in _dbContext.State on person.StateId equals state.Id into states
                         from m in states.DefaultIfEmpty()
                         select new StudentsResponse
                         {
                             Id = person.Id,
                             FirstName = person.FirstName,
                             LastName = person.LastName,
                             StateId = person.StateId,
                             Subject = person.Subject,
                             Fees = person.Fees,
                             Marks = person.Marks,
                             StateName = m.Name,
                         };
            
            return result.ToList();
        }
        public Students Detail(int id)
        {
            var Students = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            return Students;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Students = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(Students);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
        public ApplicationResponse DeleteAll(List<int> ids)
        {
            ApplicationResponse returnobj = new ApplicationResponse();

            ids.ForEach(item => {
                var Students = _dbContext.Students.FirstOrDefault(x => x.Id == item);
                if (Students != null)
                {
                    _dbContext.Remove(Students);
                    _dbContext.SaveChanges();

                }
            });

            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
