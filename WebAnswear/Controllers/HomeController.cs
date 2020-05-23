using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAnswear.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(string myNumber)
        {
            int result = MyLibrary.Convertator.convertString_Reversed(myNumber);

            StoredData.Storage.toStore(myNumber, result);
            List<StoredData.Storage.Query> data = StoredData.Storage.getStorage();

            string information = "";
            foreach(StoredData.Storage.Query element in data)
            {
                information += $"<br>---<br>ID:{element.Id}<br>Question: {element.Question} <br>" +
                                          $"Answear: {element.Answear}<br>---<br>";
            }
            return $"You choose: {result}<br>Five last elements in database:<br> " +
                        $"{information}";
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}