using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    public class Waarneming
    {
        public int ID { get; }
        public Type Type { get; }
        public int LocX { get; }
        public int LocY { get; }
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
