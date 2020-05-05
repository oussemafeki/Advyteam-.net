using Domain;

using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IMissionService : IService<mission>
    {

       // IEnumerable<mission> GetProductByCategoryName(String CatName);
      //  IEnumerable<String> GetMostFiveExpensiveProds();
     //   IEnumerable<mission> GetChemicalProds();
        //IEnumerable<mission> GetProductsByClient(Client c);
    }
}
