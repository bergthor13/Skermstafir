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

			int idValue = id.Value;
			SubtitleModel result;

            try
			{
				result = sr.GetSubtitleByID(idValue);
			}
			catch (NoSubtitleFoundException)
			{
				return View("Errors/NoSubFound");
			}
			return View(result);
        }

		// Creates a new translation
		public ActionResult CreateNewSubtitle()
		{
            SubtitleModel model = new SubtitleModel();
			return View(model);
		}

		// Edits the translation with the ID subtitleID
		public ActionResult EditSubtitle(int? subtitleID)
		{
			SearchRepository sr = new SearchRepository();

            try
            {
                int id = subtitleID.Value;
                SubtitleModel result = sr.GetSubtitleByID(id);
                return View(result);
            }
			catch (NoSubtitleFoundException)
            {
                return View("Errors/NoSubFound");
            }
		}
	}
}