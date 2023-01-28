using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Repository
{
    public class ImageDumpRepository : IImageDumpRepository
    {
        private readonly PresaleContext _dbContext;
        public ImageDumpRepository(PresaleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationResponse Upsert(ImageDump model)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            if (model.ImageId > 0)
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
        public List<ImageDump> List()
        {
            var list = _dbContext.ImageDump.ToList();
            return list;
        }
        public ApplicationResponse Delete(int id)
        {
            ApplicationResponse returnobj = new ApplicationResponse();
            var ImageDump = _dbContext.ImageDump.FirstOrDefault(x => x.ImageId == id);
            _dbContext.Remove(ImageDump);
            _dbContext.SaveChanges();
            returnobj.Success = true;
            returnobj.Message = "Data deleted Successfully";
            return returnobj;
        }
    }
}
