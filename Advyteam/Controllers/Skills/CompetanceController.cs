using Advyteam.Models;
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Advyteam.Controllers
{
    public class CompetanceController : Controller
    {
        // GET: Competance
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/competance").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<competance>>().Result;
            }
            else
            {
                ViewBag.result = null;
            }
            return View(ViewBag.result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public ActionResult Create(CompetanceModel comp)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
                Client.PostAsJsonAsync<CompetanceModel>("api/competance", comp).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/competance/" + id).Result;
            CompetanceModel cri = new CompetanceModel();
            if (response.IsSuccessStatusCode)
            {

                cri = response.Content.ReadAsAsync<CompetanceModel>().Result;

            }
            else
            {
                cri = null;
            }

            return View(cri);
        }
        public static object GetAllCompetance { get; internal set; }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/Advyteam-web/");

                // TODO: Add insert logic here
                client.DeleteAsync("api/competance/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}