using Skermstafir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skermstafir.Repositories;

namespace Skermstafir.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            ViewBag.Message = "Forsíða";
            SearchRepository sRep = new SearchRepository();
            RequestRepository rRep = new RequestRepository();
            MultipleModelLists model = new MultipleModelLists();
            model.newestRequestList = rRep.GetRequestByNewest(0, 3);
            model.popularRequestList = rRep.GetByMostPopular(0, 3);
            model.newestSubtitleList = sRep.GetSubtitleByNewest(0, 3);
            model.popularSubtitleList = sRep.GetSubtitleByMostPopular(0, 3);
			return View("Index", model);
		}

		public ActionResult Instructions()
		{
            ViewBag.Message = "Leiðbeiningar";
			return View();
		}

		public ActionResult Requests()
		{
			ViewBag.Message = "Beiðnir";
			RequestModelList result = new RequestModelList();
			RequestRepository sc = new RequestRepository();
			result = sc.GetRequestByNewest(0, 20);
			return View("Requests", result);
		}

        public ActionResult Subtitles()
        {
            ViewBag.Message = "Þýðingar";
            SubtitleModelList result = new SubtitleModelList();
			SearchRepository sc = new SearchRepository();
            result = sc.GetSubtitleByNewest(0, 20);
            return View("Subtitles", result);
        }
    }
}