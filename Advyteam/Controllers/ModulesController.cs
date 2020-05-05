using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
namespace timesheetPI.Controllers
{
    public class ModulesController : Controller
    {

        ModulesService ms = new ModulesService();
        // GET: Modules
        public ActionResult Index()
        {
            return View();
        }

        // GET: Modules/Details/5
      /*public ActionResult Details(int id)
      {
            var prods = ms.GetModulesByTachesId(id);
            return View(prods);
        }*/

        // GET: Modules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Modules/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Modules/Delete/5
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
