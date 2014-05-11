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

		// Creates a new translation
		public ActionResult CreateSubtitle()
		{
			SubtitleModel model = new SubtitleModel();
			return View(model);
		}

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

				// Mark genres of the subtitle to
				// display in the view (checkboxes)
				GenreToArray(result);

				return View(result);
			}
			catch (NoSubtitleFoundException)
			{
				return View("Errors/NoSubFound");
			}
			
        }

		// Gets the translation to be edited with the ID subtitleID
		[Authorize]
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

				// Mark genres of the subtitle to
				// display in the view (checkboxes)
				GenreToArray(result);
				
				return View(result);
            }
			catch (NoSubtitleFoundException)
            {
                return View("Errors/NoSubFound");
            }
		}

		// Takes the form data submitted and sends it to the repository.
		[Authorize]
		[HttpPost]
		public ActionResult EditSubtitle(int? id, FormCollection fd, Subtitle sub)
		{
			int idValue = id.Value;
			SubtitleModel editedSub = new SubtitleModel();
			SearchRepository search = new SearchRepository();
			var db = new SkermData();
			
			SubtitleRepository sr = new SubtitleRepository();
				
			editedSub = search.GetSubtitleByID(idValue);

			// Change the subtitle
			editedSub.subtitle.YearCreated = Convert.ToInt32(fd["year"]);
			editedSub.subtitle.Content = fd["originalText"];
			editedSub.subtitle.Description = fd["description"];

			//editedSub.subtitle.Genres = ;
			//editedSub.subtitle.Artists = ;

			sr.ChangeExistingSubtitle(idValue, editedSub);
			
			// Get the new list
			editedSub = search.GetSubtitleByID(idValue);
			// Mark genres of the subtitle to
			// display in the view (checkboxes)
			GenreToArray(editedSub);

			return View("ShowSubtitle", editedSub);
		}

		// Helper Function:
		// Puts true to an array iff the genre exists in this subtitle
		public void GenreToArray(SubtitleModel sm)
		{
			foreach (var item in sm.subtitle.Genres)
			{
				if (item.Name == "Kvikmyndir") { sm.genreValue[0] = true; }
				if (item.Name == "Þættir") { sm.genreValue[1] = true; }
				if (item.Name == "Barnaefni") { sm.genreValue[2] = true; }
				if (item.Name == "Heimildir") { sm.genreValue[3] = true; }
				if (item.Name == "Gaman") { sm.genreValue[4] = true; }
				if (item.Name == "Spenna") { sm.genreValue[5] = true; }
				if (item.Name == "Drama") { sm.genreValue[6] = true; }
				if (item.Name == "Ævintýri") { sm.genreValue[7] = true; }
			}
		}
	}

}