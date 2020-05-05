using System.Collections.Generic;
using System.Linq;
using Data.Infrastructure;
using ServicePattern;

using Domain;

namespace Service
{
    public class AffectationProjetService : Service<affectationproject>, IAffectationProjet
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public AffectationProjetService() : base(utwk)
        {

        }
        public IEnumerable<int?> GetUserByAffectationproject(int id)
        {
            return GetMany(p => p.projetaffectation_id == id).Select(p=>p.useraffectation_id);
        }
    }
}
