using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface  IProductRepository
    {
        ApplicationResponse Upsert(Product  model);
         List<Product> List();
        Product Detail(int id);
        ApplicationResponse Delete(int id);
    }
}
