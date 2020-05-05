using Data;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Services
{
    public class CategorieService : Service<categorie>, ICategorieService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public CategorieService() : base(utwk)
        {

        }
    }
}
