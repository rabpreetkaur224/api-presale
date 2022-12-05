using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System.Collections.Generic;


namespace PresaleApi.Repository
{
    public interface IPropertyTypeRepository
    {
        ApplicationResponse Upsert(PropertyType model);
        List<PropertyType> List();
        PropertyType Detail(int id);
        ApplicationResponse Delete(int id);
    }
}
