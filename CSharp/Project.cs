using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    public class Project
    {
        public int ID { get; }
        public DateTime DatumStart { get; }
        public DateTime DatumEind { get; set; }
        public string Beschrijving { get; }
        public List<Bezoek> Bezoeken { get; }

        public Project(int id, DateTime datumstart, string beschrijving)
        {
            ID = id;
            DatumStart = datumstart;
            Beschrijving = beschrijving;
        }

        public Project(int id, DateTime datumstart, DateTime datumeind, string beschrijving)
        {
            ID = id;
            DatumStart = datumstart;
            DatumEind = datumeind;
            Beschrijving = beschrijving;
        }

        public void AddBezoek(Bezoek bezoek)
        {
            Bezoeken.Add(bezoek);
        }

        public override string ToString()
        {
            string ret = Beschrijving;
            return ret;
        }
    }
}
