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
        public int ID { get; }
        [DataMember]
        public Type Type { get; }
        [DataMember]
        public int LocX { get; }
        [DataMember]
        public int LocY { get; }
        [DataMember]
        public Diersoort Diersoort { get; }

        public Waarneming(int id, Type type, int locx, int locy, Diersoort diersoort)
        {
            ID = id;
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
