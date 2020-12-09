using GeospatialProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeospatialProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        
        public ActionResult Visor(string Coordinates, string type)
        {
            List<Sismo> Sismo = new List<Sismo>();

            if(Coordinates != null)
            {
                //Construct the data
                var NewShape = StringHelper.ChangeStringByShape(type, Coordinates);

                if (type == "rectangle")
                {
                    //Use MakeEnvelope
                    var WKT = GeospatialHelper.CreateRectangleWKT(NewShape);
                    //Use Intersects
                    Sismo = GeospatialHelper.GetInformationByPolygonSismo(WKT);
                }
                else if (type == "polygon")
                {
                    //Transform
                }
                else if(type == "marker")
                {
                    //Get nearest point

                }
            }
            else
            {
                Sismo = GeospatialHelper.GetAllSismos();
            }



            return View(Sismo);
        }
        
    }
}