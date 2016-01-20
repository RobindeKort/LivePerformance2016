using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    [DataContract]
    public class Diersoort
    {
        [DataMember]
        public int ID { get; }
        [DataMember]
        public string Naam { get; }
        [DataMember]
        public string Afkorting { get; }
        [DataMember]
        public DateTime BroedStart { get; }
        [DataMember]
        public DateTime BroedEind { get; set; }
        [DataMember]
        public int BroedReq { get; }

        public Diersoort(int id, string naam, string afkorting, DateTime broedstart, DateTime broedeind, int broedreq)
        {
            ID = id;
            Naam = naam;
            Afkorting = afkorting;
            BroedStart = broedstart;
            BroedEind = broedeind;
            BroedReq = broedreq;
        }

        public override string ToString()
        {
            string ret = Naam + " (" + Afkorting + ")";
            return ret;
        }
    }
}
