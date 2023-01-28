using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IProductInquiryRepository
    {
        ApplicationResponse Upsert(ProductInquiry model);
        List<ProductInquiry> List();
        ApplicationResponse Delete(int id);
    }
}
