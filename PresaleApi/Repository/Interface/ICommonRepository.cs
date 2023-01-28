using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace PresaleApi.Repository
{
    public interface ICommonRepository
    {
        List<Dictionary<string, object>> GetData(string procName, List<SqlParameter> parameters);
    }
}
