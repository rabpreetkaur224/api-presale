using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IDepartmentRepository
    {
        ApplicationResponse Upsert(Department model);
        List<Department> List();
        Department Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);
    }
}
