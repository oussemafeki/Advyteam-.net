using Data.Infrastructure;
using Domain;

using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class MissionService : Service<mission>,IMissionService
    {
        MissionService Miss = new MissionService();

        // private MyFinanceContext ctx;
        private static IDatabaseFactory dbf = new DatabaseFactory();
        //  private IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);
        private static IUnitOfWork uow=new UnitOfWork(dbf);
        public MissionService():base(uow)
        {
            //ctx = dbf.DataContext;
            //uow = unitofwork;


        }

        public IEnumerable<mission> GetMissions()
        {
            var req = from p in GetMany()
                      where (DateTime.Now < p.dateFin)
                      select p;
            return req.OfType<mission>();
        }
       
       

        /*public IEnumerable<String> GetMostFiveExpensiveProds()
        {
            //var lamda = GetMany().OrderByDescending(p => p.Price).Select(p=>p.Name).Take(5);
            var req = (from p in GetMany()
                       orderby p.Price descending
                       select p.Name).Take(5);
            return req;

        }*/

      /*  public IEnumerable<Product> GetProductByCategoryName(string CatName)
        {
          return  GetMany(p => p.Category.Name == CatName);        
                }

        public IEnumerable<Product> GetProductsByClient(Client c)
        {
            return uow.getRepository<Facture>().GetMany(f => f.Client == c).Select(f => f.Product);
        }*/
    }
}
