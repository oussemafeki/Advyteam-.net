
using Advyteam.Models;
using Domain;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Advyteam.Controllers
{
    public class MissionController : Controller
    {
        // GET: Mission

        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = Client.GetAsync("api/missions/").Result;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.Result = response.Content.ReadAsAsync<IEnumerable<mission>>().Result;
            }
            else
            {
                ViewBag.Result = "error";
            }
            Console.WriteLine("ViewBag.Result  : " + ViewBag.Result);

            return View();

        }
        //-------Post Mission-----
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(MissionModel m)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");

            // TODO: Add insert logic here
            client.PostAsJsonAsync<MissionModel>("api/missions?nomProj=test", m)
                    .ContinueWith((postTask) => postTask.Result.ReasonPhrase.Equals("Created"));
            return RedirectToAction("Index");
        }

        // GET: demande

        public ActionResult IndexDemande()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = Client.GetAsync("api/missions/demande").Result;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.Result = response.Content.ReadAsAsync<IEnumerable<demande>>().Result;
            }
            else
            {
                ViewBag.Result = "error";
            }
            Console.WriteLine("ViewBag.Result  : " + ViewBag.Result);

            return View();

        }
        //-------Post Demande-----
        
        [HttpGet]
        public ActionResult RequestDemande( long mission_id)
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/missionsRech?id=" + mission_id).Result;
            MissionModel d = new MissionModel();

            if (response.IsSuccessStatusCode)
            {

                d = response.Content.ReadAsAsync<MissionModel>().Result;

            }
            else
            {
                d = null;
            }

            return View(d);
        }
        // POST: Project/Delete/5

        [HttpPost]
        public ActionResult RequestDemande(long mission_id, DemandeModel m)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");

                // TODO: Add insert logic here
                
                client.PostAsJsonAsync<DemandeModel>("api/missions/demandeAdd?mission_id="+mission_id, m)
                    .ContinueWith((postTask) => postTask.Result.ReasonPhrase.Equals("Created"));
                return RedirectToAction("IndexDemande");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(long id)
          {
              HttpClient client = new HttpClient();
              client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
              client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
              HttpResponseMessage response = client.GetAsync("api/rech/demande/" +id).Result;
                DemandeModel cri = new DemandeModel();
              if (response.IsSuccessStatusCode)
              {

                 cri = response.Content.ReadAsAsync<DemandeModel>().Result;

              }
             else
              {
                  cri= null;
              }

              return View(cri);
          }

          // POST: Project/Delete/5
          [HttpPost]
          public ActionResult Delete(long id, FormCollection collection)
          {
              try
              {
                  // TODO: Add delete logic here
                  HttpClient client = new HttpClient();
                  client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");

                  // TODO: Add insert logic here
                  client.DeleteAsync("api/rech/delete/" + id)
                          .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                  return RedirectToAction("IndexDemande");
              }
              catch
              {
                  return View();
              }
          }

        [HttpGet]
        public ActionResult Edit(long id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/rech/demande/" + id).Result;
            DemandeModel project = new DemandeModel();
            if (response.IsSuccessStatusCode)
            {

                project = response.Content.ReadAsAsync<DemandeModel>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            DemandeModel project = new DemandeModel();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("api/rech/demande/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                project = response.Content.ReadAsAsync<DemandeModel>().Result;
                UpdateModel(project, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
                client2.PutAsJsonAsync<DemandeModel>("rech/Approuver/"+ id, project).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("IndexDemande");
            }
            else
            {
                return View();
            }

        }







    }
}


