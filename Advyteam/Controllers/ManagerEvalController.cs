using Advyteam.Models;
using Data;
using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Advyteam.Controllers
{
    public class ManagerEvalController : Controller
    {
        ManagerEvalService MS = new ManagerEvalService();
        CritereService CS = new CritereService();
        EmployeService ES = new EmployeService();
        int toevaluate;
        // GET: ManagerEval
        public ActionResult Index(int user)
        {
            ViewBag.employename = ES.GetById(user).nom;
            IEnumerable<managereval> me = MS.GetMany(p => p.employe_id == user);
            foreach(var m in me)
            {
                m.critere = CS.GetById(m.critere_id);
            }
            ViewBag.result =me;
            if (MS.GetMany(p => p.employe_id == user).Count() != 0)
            {
                ViewBag.moy = MS.GetMany(p => p.employe_id == user).Select(f => f.value).Average();
                double avg = (double)MS.GetMany(p => p.employe_id == user).Select(f => f.value).Average();
                int avg2 = Convert.ToInt32(avg);
                ViewBag.moy2 = avg2;
            }
            else
            {
                ViewBag.moy = 0;
                ViewBag.moy2 = 0;
            }
            return View(ViewBag);
        }
        public ActionResult Home()
        {
           ViewBag.result = ES.GetMany();
            return View(ViewBag.result);
        }
        public ActionResult topthree()
        {

            IEnumerable<employe> employees = ES.GetMany();
            foreach (var e in employees)
            {
                int avg2 = Convert.ToInt32(MS.GetMany(p => p.employe_id == e.id).Select(f => f.value).Average());
                e.role = avg2.ToString();
            }
            ViewBag.result = employees.OrderByDescending(p => p.role).Take(3);
            return View(ViewBag.result);
        }
        public ActionResult Suggestion()
        {
            int Id;
            IEnumerable<employe> employees = ES.GetMany();
            foreach (var e in employees)
            {
                e.role = MS.GetMany(p => p.employe_id == e.id).Select(f => f.value).Average().ToString();
               // int.TryParse(e.role, out Id);
                Id = Convert.ToInt32(e.role);
             //   Convert.ToInt32(e.role)
                if (Id> 85)
                {
                    e.password = "Encourage him/her with 500 DT";
                }
                else if (Id > 70)
                {
                    e.password = "Encourage him/her with 200 DT";
                }
                else if (Id < 50)
                {
                    e.password = "Needs training sessions !";
                }
                else
                {
                    e.password = "";
                }
            }

            ViewBag.result = employees.Where(p=>p.password!="");
            return View(ViewBag.result);
        }
        public ActionResult Home2(int user)
        {
            // var c = from categoryuser in  MS.GetMany(f => f.employe_id == user).Select(f => f.critere) 
            //IEnumerable<critere> criteretonotShow = MS.GetMany(f => f.employe_id == user).Select(f => f.critere);
              toevaluate = user;
            ViewBag.id = user;
            ViewBag.user = ES.GetById(user).nom;
            //    var req = from c in cri

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/api/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
          //  HttpResponseMessage response = Client.GetAsync("critere/" + user).Result;
            HttpResponseMessage response = Client.GetAsync("critere").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<critere>>().Result;
            }
            else
            {
                ViewBag.result = null;
            }
            return View(ViewBag);
            
        }
        /*public ActionResult Critere (int id)
        {
            ViewBag.result = ES.GetById(id);
            return View(ViewBag.result);
        }*/
        // GET: ManagerEval/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerEval/Create
        public ActionResult Create(int criterion,int user)
        {

            
            ManagerEvalModel pm = new ManagerEvalModel();
            

           // var cat = CS.GetMany();
            //Console.WriteLine("cat"+cat);
           // pm.critere_id = 0;
           // pm.Categories = null;
           // pm.Categories = cat.Select(c => new SelectListItem
           // {
             //   Value = c.id.ToString(), Text = c.nom
           // });

            pm.NomEmploye = ES.GetById(user).nom;
            pm.NomCritere = CS.GetById(criterion).nom;
            pm.employe_id = toevaluate;
            pm.critere_id = criterion;
            Console.WriteLine("pm"+pm);

            return View(pm);

        }

        // POST: ManagerEval/Create
        [HttpPost]
        public ActionResult Create(int criterion, int user,managereval me, FormCollection collection)
        {
            me.id = 0;
            me.employe_id = user;
            me.critere_id = criterion;
            try
            {
                // TODO: Add insert logic here
               

                MS.Add(me);
                
                MS.Commit();
                return RedirectToAction("Home");
            }
            catch
            {

                
                return View();
            }
        }

        // GET: ManagerEval/Edit/5
        public ActionResult Edit(int id)
        {
            ManagerEvalModel mev = new ManagerEvalModel();
            managereval me = MS.GetById((int)id);
            mev.description = me.description;
            mev.value = me.value;

            return View(mev);
        }

        // POST: ManagerEval/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,ManagerEvalModel mev, FormCollection collection)
        {
           
            try
            {
                managereval me = new managereval();

             
                me = MS.GetById(id);
                me.description = mev.description;
                me.value = mev.value;
                MS.Update(me);
                MS.Commit();
                // TODO: Add update logic here

                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerEval/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerEval/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
            try
            {
                managereval me = new managereval();

                // TODO: Add delete logic here
                 me = MS.GetById(id);
                MS.Delete(me);
                MS.Commit();
                return RedirectToAction("Home");
            }
            catch
            {

                return View();
            }
        }
    }
}
