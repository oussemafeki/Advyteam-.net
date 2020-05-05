using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timesheetPI.Models;
using Service;

using Domain;


namespace timesheetPI.Controllers
{
    public class TachesController : Controller
    {
        TachesService ts = new TachesService();
        // GET: Taches
        public ActionResult Index()
        {
            var taches = ts.GetMany();

            return View(taches);
        }

      

        // GET: Taches/Create
        public ActionResult Create()
        {
            TachesModels pm = new TachesModels();
            return View(pm);
        }

        // POST: Taches/Create
        [HttpPost]
        public ActionResult Create(taches ta)
        {
            try
            {
                ts.Add(ta);
                ts.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Taches/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Taches/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
               // tache
              //  UpdateModel(tache, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Taches/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Taches/Delete/5
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
