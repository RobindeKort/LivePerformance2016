using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace LivePerformance2016.CSharp.Data
{
    public partial class Database
    {
        //private List<Recht> GetAllRechten()
        //{
        //    List<Recht> rechtenList = new List<Recht>();
        //    using (OracleConnection connection = Connection)
        //    {
        //        string query = "SELECT * FROM RECHT";
        //        using (OracleCommand command = new OracleCommand(query, connection))
        //        {
        //            using (OracleDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    rechtenList.Add(CreateRechtFromReader(reader));
        //                }
        //            }
        //        }
        //    }
        //    return rechtenList;
        //}
    }
}
