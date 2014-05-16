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
            // Here we would use "using" for resource management if we had more time.
			SkermData db = new SkermData();
            SearchRepository sRep = new SearchRepository(db);
            RequestRepository rRep = new RequestRepository(db);
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
            // Here we would use "using" for resource management if we had more time.
			SkermData db = new SkermData();
			RequestModelList result = new RequestModelList();
			RequestRepository sc = new RequestRepository(db);
			result = sc.GetByMostPopular(0, 100);
			return View("Requests", result);
		}

        public ActionResult Subtitles()
        {
            ViewBag.Message = "Þýðingar";
            // Here we would use "using" for resource management if we had more time.
			SkermData db = new SkermData();
            SubtitleModelList result = new SubtitleModelList();
			SearchRepository sc = new SearchRepository(db);
            result = sc.GetSubtitleByMostPopular(0, 100);
            return View("Subtitles", result);
        }
    }
}