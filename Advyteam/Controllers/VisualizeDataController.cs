using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codemode_youtube.Models;
using Newtonsoft.Json;

namespace codemode_youtube.Controllers
{
    public class VisualizeDataController : Controller
    {

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult PieChart()
        {
            return View();
        }

        public ActionResult LineChart()
        {
            return View();
        }

        public ActionResult VisualizeStudentResult()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
        }

        public List<StudentResult> Result()
        {
            List<StudentResult> stdResult = new List<StudentResult>();

            stdResult.Add(new StudentResult()
            {
                stdName = "Atir",
                marksObtained = 88
            });
            stdResult.Add(new StudentResult()
            {
                stdName = "Qasim",
                marksObtained = 60
            });
            stdResult.Add(new StudentResult()
            {
                stdName = "Hassaan Tahir",
                marksObtained = 77
            });
            stdResult.Add(new StudentResult()
            {
                stdName = "Abdul Hanan",
                marksObtained = 80
            });
            stdResult.Add(new StudentResult()
            {
                stdName = "Hassnain Ahmad",
                marksObtained = 95
            });
            stdResult.Add(new StudentResult()
            {
                stdName = "Hamza",
                marksObtained = 90
            });
            return stdResult;
        }
    }
}