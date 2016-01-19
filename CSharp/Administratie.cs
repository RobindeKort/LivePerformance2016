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

        public Administratie(IData data)
        {
            this.data = data;
        }
    }
}
