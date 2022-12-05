using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PresaleContext _dbContext;
        public ProductRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Product model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.ProductId > 0)
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

        public List<Product> List()
        {
            var list = _dbContext.Product.ToList();
            return list;
        }
        public Product Detail(int id)
        {
            var Product = _dbContext.Product.FirstOrDefault(x => x.ProductId == id);
            return Product;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Product = _dbContext.Product.FirstOrDefault(x => x.ProductId == id);
            _dbContext.Remove(Product);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }

    }

}