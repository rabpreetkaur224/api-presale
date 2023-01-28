using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PresaleContext _dbContext;
        public DepartmentRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Department model)
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

        public List<Department> List()
        {
            var list = _dbContext.Department.ToList();
            return list;
        }
        public Department Detail(int id)
        {
            var department = _dbContext.Department.FirstOrDefault(x => x.Id == id);
            return department;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Department = _dbContext.Department.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(Department);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
        public ApplicationResponse DeleteAll(List<int> ids)
        {
            ApplicationResponse returnobj = new ApplicationResponse();

            ids.ForEach(item => {
                var Department = _dbContext.Department.FirstOrDefault(x => x.Id == item);
                if (Department != null)
                {
                    _dbContext.Remove(Department);
                    _dbContext.SaveChanges();

                }
            });

            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
