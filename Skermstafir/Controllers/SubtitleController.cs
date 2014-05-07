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
		public ActionResult CreateNewSubtitle()
		{
			return View();
		}
		public ActionResult EditSubtitle(int subtitleID)
		{
			return View();
		}
	}
}