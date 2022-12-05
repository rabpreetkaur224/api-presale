using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IConstructionTypeRepository
    {
        ApplicationResponse Upsert(ConstructionType model);
        List<ConstructionType> List();
        ConstructionType Detail(int id);
        ApplicationResponse Delete(int id);
    }
}
