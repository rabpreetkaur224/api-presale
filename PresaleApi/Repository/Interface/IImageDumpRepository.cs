using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface IImageDumpRepository
    {
        ApplicationResponse Upsert(ImageDump model);
        List<ImageDump> List();
        ApplicationResponse Delete(int id);
    }
}
