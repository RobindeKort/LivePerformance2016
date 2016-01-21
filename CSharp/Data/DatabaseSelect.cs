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
        // Diersoorten worden niet meer in de Database opgeslagen
        //public List<Diersoort> GetAllDiersoorten()
        //{
        //    List<Diersoort> diersoortList = new List<Diersoort>();
        //    using (OracleConnection connection = Connection)
        //    {
        //        string query = "SELECT * FROM DIERSOORT";
        //        using (OracleCommand command = new OracleCommand(query, connection))
        //        {
        //            using (OracleDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    diersoortList.Add(CreateDiersoortFromReader(reader));
        //                }
        //            }
        //        }
        //    }
        //    return diersoortList;
        //}

        // Haalt alleen de Gebieden uit de Database
        private List<Gebied> GetAllGebiedenZonderProjecten()
        {
            List<Gebied> gebiedList = new List<Gebied>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM GEBIED";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gebiedList.Add(CreateGebiedFromReader(reader));
                        }
                    }
                }
            }
            return gebiedList;
        }

        // Haalt alleen de Projecten uit de Database en koppelt ze aan de Gebieden
        private List<Gebied> GetAllGebiedenZonderBezoeken()
        {
            List<Gebied> gebiedList = GetAllGebiedenZonderProjecten();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM \"PROJECT\"";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gebiedList = CreateProjectFromReader(reader, gebiedList);
                        }
                    }
                }
            }
            return gebiedList;
        }

        // Haalt alleen de Bezoeken uit de Database en koppelt ze aan de Projecten
        private List<Gebied> GetAllGebiedenZonderWaarnemingen()
        {
            List<Gebied> gebiedList = GetAllGebiedenZonderBezoeken();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM BEZOEK";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gebiedList = CreateBezoekFromReader(reader, gebiedList);
                        }
                    }
                }
            }
            return gebiedList;
        }

        // Haalt alleen de Waarnemingen uit de Database en koppelt ze aan de Bezoeken
        public List<Gebied> GetAllGebieden(List<Diersoort> diersoorten)
        {
            List<Gebied> gebiedList = GetAllGebiedenZonderWaarnemingen();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM WAARNEMING";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gebiedList = CreateWaarnemingFromReader(reader, gebiedList, diersoorten);
                        }
                    }
                }
            }
            return gebiedList;
        }
    }
}
