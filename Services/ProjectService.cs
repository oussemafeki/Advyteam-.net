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
  public  class ProjectService : Service<project>, IProject
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public ProjectService() : base(utwk)
        {

        }
    }
}
