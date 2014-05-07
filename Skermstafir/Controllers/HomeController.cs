using Skermstafir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skermstafir.Repositories;

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
            SubtitleModelList result = new SubtitleModelList();
			SearchRepository sc = new SearchRepository();
            result = sc.GetSubtitleByNewest(0, 5);
            return View("Subtitles", result);
        }
    }
}