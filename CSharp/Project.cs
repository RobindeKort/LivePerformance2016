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
        public int GebiedID { get; }
        public DateTime DatumStart { get; }
        public DateTime DatumEind { get; set; }
        public string Beschrijving { get; }
        public List<Bezoek> Bezoeken { get; }

        public Project(int id, DateTime datumstart, string beschrijving)
        {
            ID = id;
            DatumStart = datumstart;
            Beschrijving = beschrijving;
            Bezoeken = new List<Bezoek>();
        }

        public Project(int id, int gebiedid, DateTime datumstart, DateTime datumeind, string beschrijving)
        {
            ID = id;
            GebiedID = gebiedid;
            DatumStart = datumstart;
            DatumEind = datumeind;
            Beschrijving = beschrijving;
            Bezoeken = new List<Bezoek>();
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
