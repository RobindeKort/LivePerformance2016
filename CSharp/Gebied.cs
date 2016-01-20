﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp
{
    public class Gebied
    {
        public int ID { get; }
        public string Naam { get; }
        public List<Project> Projecten { get; }

        public Gebied(int id, string naam)
        {
            ID = id;
            Naam = naam;
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