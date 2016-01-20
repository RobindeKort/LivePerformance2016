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
        public void SaveBezoek(Bezoek bezoek)
        {
            throw new NotImplementedException();
        }

        //public void InsertReservering(Reservering reservering)
        //{
        //    using (OracleConnection connection = Connection)
        //    {
        //        string Update = "insert into reservering values(RESERVERING_FCSEQ.nextval, :TRAMID, :SPOORID)";
        //        using (OracleCommand command = new OracleCommand(Update, connection))
        //        {
        //            command.Parameters.Add(new OracleParameter("TRAMID", reservering.Tram.ID));
        //            command.Parameters.Add(new OracleParameter("SPOORID", reservering.Spoor.SpoorId));

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
