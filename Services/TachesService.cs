using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

using Domain;

using ServicePattern;

namespace Service

    
{
  public  class TachesService : Service<taches>, ITachesService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public TachesService() : base(utwk)
        {

        }

        public IEnumerable<taches> GetTachesByModuleId(int id)
        {
            return GetMany(p => p.modules_id == id).Where(p=>p.flagActif==1);
        }


        public int nbrtachetermine(int id)
        {
            return GetMany(p => p.modules.projet_id == id).Where(p => p.etat==2).Count();
        }
        public int nbrtacheNonRealise(int id)
        {
            return GetMany(p => p.modules.projet_id == id).Where(p => p.etat == 0).Count();
        }

        public int nbrtacheEnCours(int id)
        {
            return GetMany(p => p.modules.projet_id == id).Where(p => p.etat == 1).Count();
        }
        public int nombreTacheTotal(int id)
        {
            return GetMany(p => p.modules.projet_id == id).Count();
        }
        public int dateestime(int id)
        {
            return GetMany(p => p.modules.projet_id == id).Select(p => p.dateEstimer).Sum();
        }
    }
}
