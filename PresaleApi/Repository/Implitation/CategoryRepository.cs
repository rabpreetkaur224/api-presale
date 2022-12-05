using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PresaleContext _dbContext;
        public CategoryRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(Category model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.CategoryId > 0)
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
        public List<Category> List()
        {
            var list = _dbContext.Category.ToList();
            return list;
        }
        public Category Detail(int id)
        {
            var Category = _dbContext.Category.FirstOrDefault(x => x.CategoryId == id);
            return Category;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var Category = _dbContext.Category.FirstOrDefault(x => x.CategoryId == id);
            _dbContext.Remove(Category);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    } 
}
