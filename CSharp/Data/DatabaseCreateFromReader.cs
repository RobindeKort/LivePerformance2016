using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Oracle.ManagedDataAccess.Client;

namespace LivePerformance2016.CSharp.Data
{
    public partial class Database
    {
        //private Recht CreateRechtFromReader(OracleDataReader reader)
        //{
        //    return new Recht(
        //        Convert.ToInt32(reader["ID"]),
        //        Convert.ToString((reader["Omschrijving"])),
        //        Convert.ToInt32(reader["Functie_ID"])
        //        );
        //}

        //private Diersoort CreateDiersoortFromReader(OracleDataReader reader)
        //{
        //    int id = Convert.ToInt32(reader["ID"]);
        //    string naam = Convert.ToString(reader["Naam"]);
        //    string afkorting = Convert.ToString(reader["Afkorting"]);
        //    DateTime start = Convert.ToDateTime(reader["BroedStart"]);
        //    DateTime eind = Convert.ToDateTime(reader["BroedEind"]);
        //    int req = Convert.ToInt32(reader["BroedReq"]);

        //    return new Diersoort(id, naam, afkorting, start, eind, req);
        //}

        private Gebied CreateGebiedFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            string kaartpath = Convert.ToString(reader["KaartPath"]);

            return new Gebied(id, naam, kaartpath);
        }

        private List<Gebied> CreateProjectFromReader(OracleDataReader reader, List<Gebied> gebieden)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int gebiedid = Convert.ToInt32(reader["GebiedID"]);
            DateTime start = Convert.ToDateTime(reader["DatumStart"]);
            DateTime eind = Convert.ToDateTime(reader["DatumEind"]);
            string beschrijving = Convert.ToString(reader["Beschrijving"]);

            foreach (Gebied g in gebieden)
            {
                if (g.ID == gebiedid)
                {
                    g.AddProject(new Project(id, gebiedid, start, eind, beschrijving));
                }
            }

            return gebieden;
        }

        private List<Gebied> CreateBezoekFromReader(OracleDataReader reader, List<Gebied> gebieden)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int projectid = Convert.ToInt32(reader["ProjectID"]);
            DateTime start = Convert.ToDateTime(reader["DatumStart"]);
            DateTime eind = Convert.ToDateTime(reader["DatumEind"]);

            foreach (Gebied g in gebieden)
            {
                foreach (Project p in g.Projecten)
                {
                    if (p.ID == projectid)
                    {
                        p.AddBezoek(new Bezoek(id, projectid, start, eind));
                        return gebieden;
                    }
                }
            }

            return gebieden;
        }

        private List<Gebied> CreateWaarnemingFromReader(OracleDataReader reader, List<Gebied> gebieden, List<Diersoort> diersoorten)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int bezoekid = Convert.ToInt32(reader["BezoekID"]);
            string diersoort = Convert.ToString(reader["Diersoort"]);
            string typestring = Convert.ToString(reader["Type"]);
            int locx = Convert.ToInt32(reader["LocX"]);
            int locy = Convert.ToInt32(reader["LocY"]);

            Type type = Type.VA;
            if (typestring == "VA") { type = Type.VA; }
            else if (typestring == "TI") { type = Type.TI; }
            else if (typestring == "NI") { type = Type.NI; }

            Diersoort soort = null;
            foreach (Diersoort d in diersoorten)
            {
                if (d.Naam == diersoort)
                {
                    soort = d;
                    break;
                }
            }

            foreach (Gebied g in gebieden)
            {
                foreach (Project p in g.Projecten)
                {
                    foreach (Bezoek b in p.Bezoeken)
                    {
                        if (b.ID == bezoekid)
                        {
                            b.AddWaarneming(new Waarneming(id, bezoekid, type, locx, locy, soort));
                            return gebieden;
                        }
                    }
                }
            }

            return gebieden;
        }
    }
}
