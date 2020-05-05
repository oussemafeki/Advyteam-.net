using Data.Infrastructure;
using Domain;

using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeService : Service<employe>, IEmployeService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public EmployeService() : base(utwk)
        {

        }
        public IEnumerable<employe> getUserByidprojectaffectation(int id)
        {
            return GetMany(p => p.id == id);
        }
        public IEnumerable<employe> getUserByidprojectaffectationu(IEnumerable<int?> idaff)
        {
            var q =

          from x in GetMany()

          where idaff.Contains(x.id)

          select x;
            return q;
        }



    }
}
