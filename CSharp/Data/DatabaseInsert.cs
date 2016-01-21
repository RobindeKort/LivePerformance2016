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
            using (OracleConnection connection = Connection)
            {
                string Update = "insert into BEZOEK values(BEZOEK_FCSEQ.nextval, :PROJECTID, :DATUMSTART, :DATUMEIND)";
                using (OracleCommand command = new OracleCommand(Update, connection))
                {
                    command.Parameters.Add(new OracleParameter("PROJECTID", bezoek.ProjectID));
                    command.Parameters.Add(new OracleParameter("DATUMSTART", bezoek.DatumStart));
                    command.Parameters.Add(new OracleParameter("DATUMEIND", bezoek.DatumEind));

                    command.ExecuteNonQuery();
                }
            }

            foreach (Waarneming w in bezoek.Waarnemingen)
            {
                SaveWaarneming(w);
            }
        }

        public void SaveWaarneming(Waarneming waarneming)
        {
            using (OracleConnection connection = Connection)
            {
                string Update = "insert into WAARNEMING values(WAARNEMING_FCSEQ.nextval, :BEZOEKID, :DIERSOORT, :TYPE, :LOCX, :LOCY)";
                using (OracleCommand command = new OracleCommand(Update, connection))
                {
                    command.Parameters.Add(new OracleParameter("BEZOEKID", waarneming.BezoekID));
                    command.Parameters.Add(new OracleParameter("DIERSOORT", waarneming.Diersoort.Naam));
                    command.Parameters.Add(new OracleParameter("TYPE", waarneming.Type.ToString()));
                    command.Parameters.Add(new OracleParameter("LOCX", waarneming.LocX));
                    command.Parameters.Add(new OracleParameter("LOCY", waarneming.LocY));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
