using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    public class Bezoek
    {
        public int ID { get; }
        public DateTime DatumStart { get; }
        public DateTime DatumEind { get; set; }
        public List<Waarneming> Waarnemingen  { get; }

        public Bezoek(int id, DateTime datumstart)
        {
            ID = id;
            DatumStart = datumstart;
        }

        public Bezoek(int id, DateTime datumstart, DateTime datumeind)
        {
            ID = id;
            DatumStart = datumstart;
            DatumEind = datumeind;
        }

        public void AddWaarneming(Waarneming waarneming)
        {
            Waarnemingen.Add(waarneming);
        }

        public override string ToString()
        {
            string ret = ID.ToString();
            return ret;
        }
    }
}
