using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IStudentsRepository
    {
        ApplicationResponse Upsert(Students model);
        List<StudentsResponse> List();
        Students Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);
    }
}
