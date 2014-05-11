using Skermstafir.Exceptions;
using Skermstafir.Models;
using Skermstafir.Repositories;
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
        public ActionResult ShowSubtitle(int? id)
        {
			SearchRepository sr = new SearchRepository();

			if (id == null)
			{
				return View("Errors/Error");
			}

            try
			{
				int idValue = id.Value;
				SubtitleModel result;
				result = sr.GetSubtitleByID(idValue);
				return View(result);
			}
			catch (NoSubtitleFoundException)
			{
				return View("Errors/NoSubFound");
			}
			
        }

		// Creates a new translation
		public ActionResult CreateSubtitle()
		{
            SubtitleModel model = new SubtitleModel();
			return View(model);
		}

		// Edits the translation with the ID subtitleID
		public ActionResult EditSubtitle(int? id)
		{
			
			if (id == null)
			{
				return View("Errors/NoSubFound");
			}

            try
            {
				SearchRepository sr = new SearchRepository();
				int idValue = id.Value;
                SubtitleModel result = sr.GetSubtitleByID(idValue);
                return View(result);
            }
			catch (NoSubtitleFoundException)
            {
                return View("Errors/NoSubFound");
            }
		}
	}
}