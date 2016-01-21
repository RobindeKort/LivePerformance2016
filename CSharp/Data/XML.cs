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
        private DataContractSerializer dcsb;
        private DataContractSerializer dcsg;

        public XML()
        {
            dcsb = new DataContractSerializer(typeof(Bezoek), new System.Type[] { typeof(List<Waarneming>), typeof(Type), typeof(Diersoort) });
            dcsg = new DataContractSerializer(typeof (List<Gebied>), new System.Type[] { typeof(List<Project>), typeof(List<Bezoek>) });
        }

        public void SaveBezoek(Bezoek bezoek)
        {
            using (FileStream f = new FileStream(@"Bestanden\Bezoek.xml", FileMode.Create, FileAccess.Write))
            {
                dcsb.WriteObject(f, bezoek);
            }
        }

        public Bezoek GetBezoek()
        {
            using (FileStream f = new FileStream(@"Bestanden\Bezoek.xml", FileMode.Open, FileAccess.Read))
            {
                return dcsb.ReadObject(f) as Bezoek;
            }
        }

        public void SaveGebieden(List<Gebied> gebieden)
        {
            using (FileStream f = new FileStream(@"Bestanden\Gebieden.xml", FileMode.Create, FileAccess.Write))
            {
                dcsg.WriteObject(f, gebieden);
            }
        }

        public List<Gebied> GetGebieden()
        {
            using (FileStream f = new FileStream(@"Bestanden\Gebieden.xml", FileMode.Open, FileAccess.Read))
            {
                return dcsg.ReadObject(f) as List<Gebied>;
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
