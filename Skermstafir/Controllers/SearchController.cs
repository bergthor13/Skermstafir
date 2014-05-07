using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skermstafir.Models;
using Skermstafir.Repositories;

namespace Skermstafir.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
		// FormData PARAMETER
        public ActionResult Search()
        {
			List<SubtitleModel> result = new List<SubtitleModel>();
			SearchRepository sc = new SearchRepository();

			result = sc.GetSubtitleByNewest(0, 5);

			return View("Subtitles", result);
        }
	}
}