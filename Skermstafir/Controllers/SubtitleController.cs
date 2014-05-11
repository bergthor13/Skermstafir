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
				// Go through each genre.
				foreach (var item in result.subtitle.Genres)
				{
					if (item.Name == "Kvikmyndir")	  { result.genreValue[0] = true; }
					if (item.Name == "Þættir")		  { result.genreValue[1] = true; }
					if (item.Name == "Teiknimyndir")  { result.genreValue[2] = true; }
					if (item.Name == "Heimildarefni") { result.genreValue[3] = true; }
					if (item.Name == "Gaman")		  { result.genreValue[4] = true; }
					if (item.Name == "Spenna")		  { result.genreValue[5] = true; }
					if (item.Name == "Drama")		  { result.genreValue[6] = true; }
					if (item.Name == "Ævintýri")	  { result.genreValue[7] = true; }
				}
				return View(result);
			}
			catch (NoSubtitleFoundException)
			{
				return View("Errors/NoSubFound");
			}
			
        }

		// Creates a new translation
		public ActionResult CreateNewSubtitle()
		{
            SubtitleModel model = new SubtitleModel();
			return View(model);
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

			return View("ShowSubtitle", editedSub);
		}
	}
}