using Advyteam.Models;
using Data;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Types;
//using Rotativa;
//using Nexmo.Api;
using System.Net;
using Domain;

namespace Advyteam.Controllers
{

    public class CongeController : Controller
    {
        ICongeService cs = new CongeService();
        // GET: Conge
        public ActionResult Index()
        {

            List<CongeModels> lc = new List<CongeModels>();
            foreach (var cm in cs.GetMany())
            {
                CongeModels c = new CongeModels();
                c.id = cm.id;
                c.DateDebut = cm.DateDebut;
                c.DateFin = cm.DateFin;
                c.typeConge = cm.typeConge;
                c.certefica = cm.certefica;

                lc.Add(c);
            }
           
            return View(lc);
        }

        // GET: Conge/Details/5
        public ActionResult Details(int id)
        {

            conge cm = new conge();
            CongeModels c = new CongeModels();
            cm = cs.Get(t => t.id == id);

            c.DateDebut = cm.DateDebut;
            c.DateFin = cm.DateFin;
            ViewBag.id = cm.id;
            ViewBag.nbr_jrs =cm.nbr_jr ;
            ViewBag.reponse = cm.reponse;
            ViewBag.typedeconge = cm.typeConge;

            ViewBag.certificat = cm.certefica;

            return View(c);
        }

        // GET: Conge/Create
        public ActionResult Create()
        {
            var types = new List<SelectTypeModels>();
            types.Add(new SelectTypeModels() { Value = 0, Text = "Select a Type" });
            types.Add(new SelectTypeModels() { Value = 1, Text = "Conge" });
            types.Add(new SelectTypeModels() { Value = 2, Text = "Maladie" });
            ViewBag.PartialTypes = types;
            return View();
        }

        // POST: Conge/Create
        [HttpPost]
        public ActionResult Create(CongeModels cm, HttpPostedFileBase file)
        {
            {
                if (!ModelState.IsValid || file == null || file.ContentLength == 0)

                    RedirectToAction("Create");
            }
            conge c = new conge();

            c.id = cm.id;
            c.typeConge = cm.typeConge;
            if (c.typeConge == "Maladie")
            {

                c.certefica = file.FileName;
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.
                        Combine(Server.MapPath("~/Content/Upload/"),
                        fileName);
                    file.SaveAs(path);
                }
            }
            else if (c.typeConge=="Normale")
            {
                c.certefica = "N'a pas besoin de certificat";
            }
            c.DateDebut = cm.DateDebut;
            c.DateFin = cm.DateFin;
            c.reponse = "false";
            c.typeConge = cm.typeConge;
            c.demandeConge = "true";
            //c.certefica = cm.certefica;

            //calcule nbr jours conge
           // System.TimeSpan diff1 = c.DateFin.Subtract(DateTime.Now);
          //  int x = (int)diff1.TotalDays;
            //c.nbr_jr = x;
           
            cs.Add(c);
            cs.Commit();
            
            return RedirectToAction("Index");

        }

        // GET: Conge/Edit/5
        public ActionResult Edit(int id)
        {
            conge cm = new conge();

            cm = cs.Get(t => t.id == id);
            CongeModels c = new CongeModels();
            c.DateDebut = cm.DateDebut;
            c.DateFin = cm.DateFin;
            c.certefica = cm.certefica;
            c.typeConge = cm.typeConge;


            return View(c);
        }

        // POST: Conge/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CongeModels cm, HttpPostedFileBase file)
        {
            {
                if (!ModelState.IsValid || file == null || file.ContentLength == 0)

                    RedirectToAction("Create");
            }
            conge c = new conge();
            c = cs.Get(t => t.id == id);
            c.id = cm.id;

            c.DateDebut = cm.DateDebut;
            c.DateFin = cm.DateFin;
            c.typeConge=cm.typeConge;
            if (c.typeConge == "Maladie")
            {

                c.certefica = file.FileName;
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.
                        Combine(Server.MapPath("~/Content/Upload/"),
                        fileName);
                    file.SaveAs(path);
                }
            }
            else if (c.typeConge == "Normale")
            {
                c.certefica = "N'a pas besoin de certificat";
            }
            cs.Update(c);
            cs.Commit();
           
            return RedirectToAction("Index");
        }

        // GET: Conge/Delete/5
        public ActionResult Delete(int id)
        {
            conge cm = new conge();

            cm = cs.Get(t => t.id == id);
            CongeModels c = new CongeModels();
            c.DateFin = cm.DateFin;
            c.DateDebut = cm.DateDebut;
            return View(c);
        }

        // POST: Conge/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            conge c = new conge();
            c = cs.Get(t => t.id == id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult IndexAdmin()
        {

            List<CongeModels> lc = new List<CongeModels>();
            foreach (var cm in cs.GetMany())
            {
                CongeModels c = new CongeModels();
                c.id = cm.id;
                c.DateDebut = cm.DateDebut;
                c.DateFin = cm.DateFin;
                c.typeConge = cm.typeConge;
                c.certefica = cm.certefica;

                lc.Add(c);
            }
           
            return View(lc);
        }
        public ActionResult DetailsAdmin(int id)
        {

            conge cm = new conge();
            CongeModels c = new CongeModels();
            cm = cs.Get(t => t.id == id);

            c.DateDebut = cm.DateDebut;
            c.DateFin = cm.DateFin;
            c.certefica = cm.certefica;
            c.typeConge = cm.typeConge;
            ViewBag.id = cm.id;
            ViewBag.reponse = cm.reponse;
            ViewBag.nbr_jrs = cm.nbr_jr;
            return View(c);

        }
        //SMS
        [HttpPost]
        public JsonResult IndexAdminAction(int idConge)
        {
           var res = cs.GetById(idConge);
            res.reponse = "true";
            //System.TimeSpan diff1 = res.DateFin.Subtract(DateTime.Now);
          //  int x = (int)diff1.TotalDays;
           // res.nbr_jr = x;
         /*   var client = new Nexmo.Api.Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "8f32e036",
                ApiSecret = "LxCTc3I4c26h5cZV"
            });*/
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

           /* var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Nexmo",
                to = "21624624028",
                text = "Votre Conges est Accepté"
            });*/
            cs.Update(res);
            cs.Commit();
            return Json("");

        }
   
        
    


      /*  public ActionResult ExportPDF()
        {
            return new UrlAsImage("/Content/img/66352633_346506392713239_1528669054959616000_n.png")

            {
                FileName = Server.MapPath("~/Content/certificat.png")
            };

        }*/
        
    }
}

