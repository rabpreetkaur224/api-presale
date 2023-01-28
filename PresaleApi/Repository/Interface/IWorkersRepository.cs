using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IWorkersRepository
    {
        ApplicationResponse Upsert(Workers model);
        List<WorkersView> List();
        Workers Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);
    }
}
