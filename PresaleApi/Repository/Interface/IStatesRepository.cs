using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IStatesRepository
    {
        ApplicationResponse Upsert(States model);
        List<States> List();
        States Detail(int id);
        ApplicationResponse Delete(int id);
        ApplicationResponse DeleteAll(List<int> ids);
    }
}
