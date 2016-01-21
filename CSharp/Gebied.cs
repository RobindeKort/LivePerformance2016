using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    [DataContract]
    public class Gebied
    {
        [DataMember]
        public int ID { get; private set; }
        [DataMember]
        public string Naam { get; private set; }
        [DataMember]
        public string KaartPath { get; private set; }
        [DataMember]
        public List<Project> Projecten { get; private set; }

        public Gebied(int id, string naam, string kaartpath)
        {
            ID = id;
            Naam = naam;
            KaartPath = kaartpath;
            Projecten = new List<Project>();
        }

        public void AddProject(Project project)
        {
            Projecten.Add(project);
        }

        public override string ToString()
        {
            string ret = Naam;
            return ret;
        }
    }
}
