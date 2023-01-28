using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IStateRepository
    {
        ApplicationResponse Upsert(State model);
        List<State> List();
        State Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);

    }
}
