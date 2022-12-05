using PresaleApi.DataBaseEntity;
using System;
using System.Collections.Generic;

namespace PresaleApi.Repository
{
    public interface INearByRepository
    {
        ApplicationResponse Upsert(NearBy model);
        List<NearBy> List();
        NearBy Detail(int id);
        ApplicationResponse Delete(int id);
    }
}
