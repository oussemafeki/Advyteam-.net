using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Advyteam.Models;
using Data;
using Newtonsoft.Json.Linq;

namespace Advyteam.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
             Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/employes").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<EmployeModels>>().Result.ToList();
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }

        // GET: Employe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        [HttpPost]
        public ActionResult Create(EmployeModels p)
        {
            var employe = new JObject();
            employe.Add("email", p.email);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");

            // TODO: Add insert logic here
            client.PostAsJsonAsync("rest/employes",employe)
                    .ContinueWith((postTask) => postTask.Result.ReasonPhrase.Equals("Created"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/employes/" + id).Result;
            EmployeModels project = new EmployeModels();
            if (response.IsSuccessStatusCode)
            {

                project = response.Content.ReadAsAsync<EmployeModels>().Result;

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

            EmployeModels project = new EmployeModels();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("rest/employes/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                project = response.Content.ReadAsAsync<EmployeModels>().Result;
                UpdateModel(project, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
                client2.PutAsJsonAsync<EmployeModels>("rest/employes", project).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET: Employe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
