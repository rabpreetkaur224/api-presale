using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class ProductInquiryRepository : IProductInquiryRepository
    {
        private readonly PresaleContext _dbContext;
        public ProductInquiryRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(ProductInquiry model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.ProductInquiryId > 0)
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
        public List<ProductInquiry> List()
        {
            var list = _dbContext.ProductInquiry.ToList();
            return list;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var ProductInquiry = _dbContext.ProductInquiry.FirstOrDefault(x => x.ProductInquiryId == id);
            _dbContext.Remove(ProductInquiry);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
