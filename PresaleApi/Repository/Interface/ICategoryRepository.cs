using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface  ICategoryRepository
    {
        ApplicationResponse Upsert(Category model);
        List<Category> List();
        Category Detail(int id);
        ApplicationResponse Delete(int id);
    }
}
