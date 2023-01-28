using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using PresaleApi.DataBaseEntity;
using Newtonsoft.Json;

namespace PresaleApi.Repository
{
    public class CommonRepository : ICommonRepository
    {
        public List<Dictionary<string, object>> GetData(string procName, List<SqlParameter> parameters)
        {
            var list = new List<Dictionary<string, object>>();
            try
            {
                string ConnectionString = @"data source=DESKTOP-VF6GA3A; database=Presale; User ID=sa;Password=123456;Trusted_Connection=True;MultipleActiveResultSets=True;";
                List<Dictionary<string, object>> returnObjects = new List<Dictionary<string, object>>();
                DataTable dt = new DataTable();
                //Create the SqlConnection object
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = procName, //Specify the Stored procedure name
                        Connection = connection, //Specify the connection object where the stored procedure is going to execute
                        CommandType = CommandType.StoredProcedure //Specify the command type as Stored Procedure
                    };
                    //Create an instance of SqlParameter
                    if (parameters != null)
                    {
                        parameters.ForEach(x =>
                        {
                            cmd.Parameters.Add(x);

                        });
                    }
                    //Add the parameter to the Parameters property of SqlCommand object
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var dict = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            dict[col.ColumnName] = row[col];
                        }
                        list.Add(dict);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;

        }

    }
}
