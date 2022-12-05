using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IFeatureRepository
    {
        ApplicationResponse Upsert(Feature model);
        List<Feature> List();
        Feature Detail(int id);
        ApplicationResponse Delete(int id);
    }
}
