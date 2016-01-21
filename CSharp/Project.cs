using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    [DataContract]
    public class Project
    {
        [DataMember]
        public int ID { get; private set; }
        [DataMember]
        public int GebiedID { get; private set; }
        [DataMember]
        public DateTime DatumStart { get; private set; }
        [DataMember]
        public DateTime DatumEind { get; set; }
        [DataMember]
        public string Beschrijving { get; private set; }
        public List<Bezoek> Bezoeken { get; private set; }

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
            if (Bezoeken == null)
            {
                Bezoeken = new List<Bezoek>();
            }
            Bezoeken.Add(bezoek);
        }

        public override string ToString()
        {
            string ret = Beschrijving;
            return ret;
        }
    }
}
