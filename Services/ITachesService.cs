using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using ServicePattern;


namespace Service
{
    interface ITachesService : IService<taches>
    {
        IEnumerable<taches> GetTachesByModuleId(int id);
        int nbrtacheEnCours(int id);
        int nbrtachetermine(int id);
        int nombreTacheTotal(int id);
        int nbrtacheNonRealise(int id);
       
    }
}
