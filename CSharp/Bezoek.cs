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
        public int ID { get; }
        [DataMember]
        public DateTime DatumStart { get; }
        [DataMember]
        public DateTime DatumEind { get; set; }
        [DataMember]
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
