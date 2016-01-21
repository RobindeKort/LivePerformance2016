using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformance2016.CSharp.Data
{
    public interface IData
    {
        // Interface om altijd een Bezoek op te kunnen slaan (online/offline)
        void SaveBezoek(Bezoek bezoek);
        //List<Diersoort> GetAllDiersoorten();

        //List<Animal> GetAllAnimals();
        //void SaveAllAnimals();

        //void SaveAnimal(Animal animal);
        //void UpdateAnimal(Animal animal);
        //void DeleteAnimal(Animal animal);
    }
}
