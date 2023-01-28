using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface ICmsRepository
    {
        ApplicationResponse Upsert(Cms model);
        List<Cms> List();
        ApplicationResponse Delete(int id);
    }
}
