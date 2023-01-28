using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IContactUsRepository
    {
        ApplicationResponse Upsert(ContactUs model);
        List<ContactUs> List();
        ApplicationResponse Delete(int id);
    }
}
