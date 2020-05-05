

using Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace Advyteam.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Advyteam-web/api/training").Result;
            

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<training>>().Result;
            }
            else
            {
                ViewBag.result = "error";

            }
            return View();
            
        }
        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Advyteam-web/api/training" + id).Result;
            training training = new training();
            if (response.IsSuccessStatusCode)
            {

                training = response.Content.ReadAsAsync<training>().Result;

            }
            else
            {
                ViewBag.training = "erreur";
            }

            return View(training);
        }

        public ActionResult CreateDocument()
        {
            //Create an instance of PdfDocument.
          /*  using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

                // Open the document in browser after saving it
                document.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
            }*/
            return View();
        }



    }
}