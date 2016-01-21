using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    [DataContract]
    public class Waarneming
    {
        [DataMember]
        public int ID { get; private set; }
        [DataMember]
        public int BezoekID { get; private set; }
        [DataMember]
        public Type Type { get; private set; }
        [DataMember]
        public int LocX { get; private set; }
        [DataMember]
        public int LocY { get; private set; }
        [DataMember]
        public Diersoort Diersoort { get; private set; }

        public Waarneming(int id, int bezoekid, Type type, int locx, int locy, Diersoort diersoort)
        {
            ID = id;
            BezoekID = bezoekid;
            Type = type;
            LocX = locx;
            LocY = locy;
            Diersoort = diersoort;
        }

        public override string ToString()
        {
            string ret = Diersoort.ToString() + " " + Type.ToString();
            return ret;
        }
    }
}
