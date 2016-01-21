using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    [DataContract]
    public class Bezoek
    {
        [DataMember]
        public int ID { get; private set; }
        [DataMember]
        public int ProjectID { get; private set; }
        [DataMember]
        public DateTime DatumStart { get; private set; }
        [DataMember]
        public DateTime DatumEind { get; set; }
        [DataMember]
        public List<Waarneming> Waarnemingen  { get; private set; }

        public Bezoek(int id, int projectid, DateTime datumstart)
        {
            ID = id;
            ProjectID = projectid;
            DatumStart = datumstart;
            Waarnemingen = new List<Waarneming>();
        }

        public Bezoek(int id, int projectid, DateTime datumstart, DateTime datumeind)
        {
            ID = id;
            ProjectID = projectid;
            DatumStart = datumstart;
            DatumEind = datumeind;
            Waarnemingen = new List<Waarneming>();
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
