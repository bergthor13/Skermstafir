using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skermstafir.Controllers
{
    public class SubtitleController : Controller
    {
        //
        // GET: /Subtitle/
        public ActionResult Subtitle(int subtitleID)
        {
            return View();
        }

		// Creates a new translation
		public ActionResult CreateNewSubtitle()
		{
			return View();
		}

		// Edits the translation with the ID subtitleID
		public ActionResult EditSubtitle(int subtitleID)
		{
			return View();
		}
	}
}