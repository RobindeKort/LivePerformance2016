using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp.Data
{
    public class XML : IData
    {
        private DataContractSerializer dcs;

        public XML()
        {
            dcs = new DataContractSerializer(typeof(Bezoek), new System.Type[] { typeof(List<Waarneming>), typeof(Type), typeof(Diersoort) });
        }

        public void SaveBezoek(Bezoek bezoek)
        {
            using (FileStream f = new FileStream("Bezoek.xml", FileMode.Create, FileAccess.Write))
            {
                dcs.WriteObject(f, bezoek);
            }
        }

        public Bezoek GetBezoek()
        {
            using (FileStream f = new FileStream("Bezoek.xml", FileMode.Open, FileAccess.Read))
            {
                return dcs.ReadObject(f) as Bezoek;
            }
        }

        //public List<Diersoort> GetAllDiersoorten()
        //{
        //    throw new NotImplementedException();
        //}

        //public Bezoek GetBezoek(string path)
        //{
        //    Bezoek bezoek = new Bezoek();
        //    return bezoek;
        //}
    }
}
