using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    public class Diersoort
    {
        public int ID { get; }
        public string Naam { get; }
        public string Afkorting { get; }
        public DateTime BroedStart { get; }
        public DateTime BroedEind { get; set; }
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
