using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IEmployeeRepository
    {
        ApplicationResponse Upsert(Employee model);
        List<EmployeeResponse> List();
        Employee Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);

    }
}
