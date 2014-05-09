using Skermstafir.Models;
using Skermstafir.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skermstafir.Models;

namespace Skermstafir.Controllers
{
    public class SubtitleController : Controller
    {
        //
        // GET: /Subtitle/
        public ActionResult ShowSubtitle(int? subtitleID)
        {
			SearchRepository sr = new SearchRepository();
			SubtitleModel result = sr.GetSubtitleByID(5);
			return View(result);
        }

		// Creates a new translation
		public ActionResult CreateNewSubtitle()
		{
			return View();
		}

		// Edits the translation with the ID subtitleID
		public ActionResult EditSubtitle(int? subtitleID)
		{
            SubtitleModel model = new SubtitleModel();
			return View(model);
		}
	}
}