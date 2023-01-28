using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class ContactUsRepository : IContactUsRepository 
    {
        private readonly PresaleContext _dbContext;
        public ContactUsRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(ContactUs model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.ContactUsId > 0)
            {
                _dbContext.Update(model);
                _dbContext.SaveChanges();

            }
            else
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }
            returnobj.Success = true;
            returnobj.Message = "Data Saved Successfully";
            return returnobj;
        }
        public List<ContactUs> List()
        {
            var list = _dbContext.ContactUs.ToList();
            return list;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var ContactUs = _dbContext.ContactUs.FirstOrDefault(x => x.ContactUsId == id);
            _dbContext.Remove(ContactUs);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
