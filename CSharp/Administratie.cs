using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance2016.CSharp.Data;

namespace LivePerformance2016.CSharp
{
    public partial class Administratie
    {
        private IData data;
        public List<Diersoort> Diersoorten { get; private set; }
        public List<Gebied> Gebieden { get; private set; }

        public Administratie(IData idata)
        {
            Diersoorten = new List<Diersoort>();
            Gebieden = new List<Gebied>();
            data = idata;

            GetAllDiersoorten();
            if (data.GetType() == typeof(Database))
            {
                Database d = (Database)data;
                Gebieden = d.GetAllGebieden(Diersoorten);
                new XML().SaveGebieden(Gebieden);
            }
            else if (data.GetType() == typeof (XML))
            {
                XML x = (XML)data;
                Gebieden = x.GetGebieden();
            }
        }

        // Importeert alle vogelsoorten uit een tekstbestand (broedvogels.csv)
        // en stopt deze in de list diersoorten
        private void GetAllDiersoorten()
        {
            Diersoorten = new List<Diersoort>();
            string path = @"Bestanden\broedvogels.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    int een = line.IndexOf(";", 0);
                    int twee = line.IndexOf(";", een + 1);
                    int drie = line.IndexOf(";", twee + 1);
                    int vier = line.IndexOf(";", drie + 1);
                    string naam = line.Substring(0, een);
                    string afko = line.Substring(een + 1, twee - een - 1);
                    string start = line.Substring(twee + 1, drie - twee - 1);
                    int startdag = Convert.ToInt32(start.Substring(0, start.IndexOf("-")));
                    int startmaand = Convert.ToInt32(start.Substring(start.IndexOf("-") + 1));
                    string eind = line.Substring(drie + 1, vier - drie - 1);
                    int einddag = Convert.ToInt32(eind.Substring(0, eind.IndexOf("-")));
                    int eindmaand = Convert.ToInt32(eind.Substring(eind.IndexOf("-") + 1));
                    int req = Convert.ToInt32(line.Substring(vier + 1));
                    Diersoorten.Add(new Diersoort(naam, afko, new DateTime(1900, startmaand, startdag),
                                                              new DateTime(1900, eindmaand, einddag), req));
                }
            }
            return;
        }

        public void SaveBezoek(Bezoek bezoek)
        {
            data.SaveBezoek(bezoek);
        }
    }
}
