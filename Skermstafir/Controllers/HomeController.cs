using Skermstafir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skermstafir.Controllers
{
    [RequireHttps]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Instructions()
		{
            ViewBag.Message = "Leiðbeiningar";
			return View();
		}

		public ActionResult Requests()
		{
			ViewBag.Message = "Beiðnir";

			return View();
		}

        public ActionResult Subtitles()
        {
            ViewBag.Message = "Þýðingar";
			SearchController sc = new SearchController();
			sc.Search();
			
            return View("Subtitles");
        }
	}
}