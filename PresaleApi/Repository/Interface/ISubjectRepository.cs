using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface ISubjectRepository
    {
        ApplicationResponse Upsert(Subject model);
        List<Subject> List();
        Subject Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);
    }
}
