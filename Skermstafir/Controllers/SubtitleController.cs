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
				return View("Errors/NoSubFound");
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
		[HttpGet]
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

		// Takes the form data submitted and sends it to the repository.
		[HttpPost]
		public ActionResult EditSubtitle(int? id, FormCollection fd, Subtitle sub)
		{
			int idValue = id.Value;
			SubtitleModel editedSub = new SubtitleModel();
			SearchRepository search = new SearchRepository();
			using (var db = new SkermData())
			{
				SubtitleRepository sr = new SubtitleRepository();
				
				editedSub = search.GetSubtitleByID(idValue);
				editedSub.subtitle.YearCreated = Convert.ToInt32(fd["year"]);
				sr.ChangeExistingSubtitle(idValue, editedSub);

			}
			editedSub = search.GetSubtitleByID(idValue);
			// Works when debugged, but not otherwise.
			return View("ShowSubtitle", editedSub);
		}
	}
}