using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using timesheetPI.Models;
using Domain;
using Service;
using System.Net.Mail;
using System.Web.Helpers;

using Services;

namespace timesheetPI.Controllers
{
    public class ProjectController : Controller
    {
        ProjectService ps = new ProjectService();
        ModulesService ms = new ModulesService();
        TachesService ts = new TachesService();
        AffectationProjetService afp =new AffectationProjetService();
        EmployeService us = new EmployeService();

        // GET: Modules/Details/5
        public ActionResult DetailsModules(int id)
        {
            var n =id;
            ViewBag.idd= n;

            var prods = ms.GetModulesByTachesId(id);
            return View(prods);


        }
        public ActionResult DetailsTaches(int idt)
        {
          
            var tach = ts.GetTachesByModuleId(idt);
         
            return View(tach);


        }
        // GET: Project
        public ActionResult Index()
        {
            

            HttpClient  Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Advyteam-web/api/project").Result;
            IEnumerable<ProjectModels> projects;
            if (response.IsSuccessStatusCode)
            {
                projects = response.Content.ReadAsAsync<IEnumerable<ProjectModels>>().Result;
            }
            else
            {
                projects = null;
            }
            ViewBag.Result = projects;
            return View();
        }
     
  public ActionResult DetailsProjet(int id)
        {
            ViewBag.idd = id;
            var nbrtachetermine = ts.nbrtachetermine(id);
            var nbrtacheEncour = ts.nbrtacheEnCours(id);
            var nbrtt = ts.nombreTacheTotal(id);
            var nbrtNR = ts.nbrtacheNonRealise(id);
            ViewBag.nbrtacheNonRealise = nbrtNR;
            ViewBag.nombretachetermine = nbrtachetermine;
            ViewBag.nbrtacheEncour = nbrtacheEncour;
            ViewBag.nombreTotelTache = nbrtt;

            var stat = nbrtachetermine * 100 / nbrtt;
            ViewBag.stat = stat;

            var idUseraffectationProjet = afp.GetUserByAffectationproject(id);

           

            var utilisateur = us.getUserByidprojectaffectationu(idUseraffectationProjet);
            ViewBag.user = utilisateur;

            var dateestimer = ts.dateestime(id);
            ViewBag.dateestimer = dateestimer;
          
            project pro = ps.GetById(id);
            ViewBag.description = pro.description;
            ViewBag.titre = pro.title;
            ViewBag.dateDebutProjet = pro.dateDebutProjet;
              return View();

            


        }
     

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProjectModels p)
        {
            p.flagActif = 0;
           p.dateDebutProjet = System.DateTime.Now;

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
           // Client.PostAsJsonAsync<ProjectModels>("Advyteam-web/api/project", p).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            var createTask = Client.PostAsJsonAsync<ProjectModels>("Advyteam-web/api/project", p);
            createTask.Wait();

            var result = createTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateModule(int idp)
        {
            return View("CreateModule");
        }

        [HttpPost]
        public ActionResult CreateModule(modules p,int idp)
        {
            p.projet_id = idp;
            p.flagActif = 1;
            ms.Add(p);
            ms.Commit();
            ViewBag.idd = idp;
          
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Createtache(int idm)
        {
            return View("Createtache");
        }

        [HttpPost]
        public ActionResult Createtache(taches p, int idm)
        {
            p.modules_id= idm;
            p.flagActif = 1;
            ts.Add(p);
            ts.Commit();

            return RedirectToAction("index");
        }

        public ActionResult DeleteProject(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Advyteam-web/api/project/" + id).Result;
            ProjectModels p = new ProjectModels();
            if (response.IsSuccessStatusCode)
            {

                p = response.Content.ReadAsAsync<ProjectModels>().Result;

            }
            else
            {
                p = null;
            }

            return View(p);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult DeleteProject(int id, FormCollection collection)
        {
            try
            {
                
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080");

                // TODO: Add insert logic here
                // client.DeleteAsync("Advyteam-web/api/project/" + id)
                   //     .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                var deleteTask = client.DeleteAsync("Advyteam-web/api/project/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        // GET: Taches/Delete/5
        public ActionResult deletetache(int idt)
        {
            var item = ms.GetById(idt);
            item.flagActif = 0;
        

            return RedirectToAction("Index");
        }

        // GET: Modules/Edit/5
        public ActionResult updatetache(int idt)
        {
            var f=ms.GetById(idt);   
            return View(f);
           
        }
        [HttpPost]
        public ActionResult updatetache(modules f, FormCollection collection)
        {
            var f1 = ms.GetById(f.id);

            f1.nomModule = f.nomModule;
f1.descriptionModule = f.descriptionModule;


            ms.Commit();
          
            

            return RedirectToAction("Index");
        }


        public ActionResult reunion(int id)
        {
            var idUseraffectationProjet = afp.GetUserByAffectationproject(id);
            var user = us.getUserByidprojectaffectationu(idUseraffectationProjet);

            using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("farahfarahmarsaoui@gmail.com");
                    mail.To.Add(user.First().email);
                    mail.Subject = "palnification d'une reunion";
                    mail.Body = "<h1>suite a votre avancement une reunion sera planifier </h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("farahfarahmarsaoui@gmail.com", "motdepassefarah");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        ViewBag.msg = "mail sent";
                        return RedirectToAction("Index");
                    }

                }
            }
           
        }
    }
