using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface ITeachersRepository
    {
        ApplicationResponse Upsert(Teachers model);
        List<TeacherView> List();
        Teachers Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);
    }
}
