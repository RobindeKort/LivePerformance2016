using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePerformance2016.CSharp.Data;

namespace LivePerformance2016.CSharp
{
    public partial class Administratie
    {
        private IData data;
        private List<Diersoort> diersoorten;
        private List<Gebied> gebieden; 

        public Administratie(IData idata)
        {
            data = idata;
            GetAllDiersoorten();
            if (data.GetType() == typeof(Database))
            {
                Database d = (Database) data;
                gebieden = d.GetAllGebieden(diersoorten);
            }
        }

        private void GetAllDiersoorten()
        {
            throw new NotImplementedException();
            diersoorten = new List<Diersoort>();
            return;
        }
    }
}
