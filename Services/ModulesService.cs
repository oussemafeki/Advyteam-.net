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
   public class ModulesService : Service<modules>, IModulesService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public ModulesService() : base(utwk)
        {

        }

        public IEnumerable<modules> GetModulesByTachesId(int id)
        {
            return GetMany(p => p.projet_id== id).Where(p => p.flagActif == 1);
        }
       

    }
}
