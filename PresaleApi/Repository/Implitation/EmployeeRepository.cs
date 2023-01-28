using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PresaleContext _dbContext;
        public EmployeeRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Employee model)
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
        public List<EmployeeResponse> List()
        {
            //var list = _dbContext.Employee.ToList();
            var result = from person in _dbContext.Employee
                         join department in _dbContext.Department on person.DepartmentId equals department.Id into departments
                         from m in departments.DefaultIfEmpty()
                         select new EmployeeResponse
                         {
                             Id = person.Id,
                             FirstName = person.FirstName,
                             LastName = person.LastName,
                             DepartmentId = person.DepartmentId,
                             Gender = person.Gender,
                             Salary = person.Salary,
                             DepartmentName = m.Name,
                         };
            return result.ToList();
        }
        public Employee Detail(int id)
        {
            var Employee = _dbContext.Employee.FirstOrDefault(x => x.Id == id);
            return Employee;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Employee = _dbContext.Employee.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(Employee);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
        public ApplicationResponse DeleteAll(List<int> ids)
        {
            ApplicationResponse returnobj = new ApplicationResponse();

            ids.ForEach(item => {
                var Employee = _dbContext.Employee.FirstOrDefault(x => x.Id == item);
                if(Employee != null)
                {
                    _dbContext.Remove(Employee);
                    _dbContext.SaveChanges();

                }
            });
           
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
