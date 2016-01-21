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
        public string Naam { get; private set; }
        [DataMember]
        public string Afkorting { get; private set; }
        [DataMember]
        public DateTime BroedStart { get; private set; }
        [DataMember]
        public DateTime BroedEind { get; set; }
        [DataMember]
        public int BroedReq { get; private set; }

        public Diersoort(string naam, string afkorting, DateTime broedstart, DateTime broedeind, int broedreq)
        {
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
