using Skermstafir.Exceptions;
using Skermstafir.Models;
using Skermstafir.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Skermstafir.Controllers
{
    public class SubtitleController : Controller
    {

		/// <summary>
		/// Creates a new translation.
		/// </summary>
		[Authorize]
		[HttpGet]
		public ActionResult CreateSubtitle()
		{
			SubtitleModel model = new SubtitleModel();
			return View(model);
		}

		/// <summary>
		/// Creates a new translation.
		/// </summary>
		[Authorize]
		[HttpPost]
		public ActionResult CreateSubtitle(FormCollection fc)
		{
			SubtitleModel model = new SubtitleModel();
			return View(model);
		}

		/// <summary>
		/// Creates a subtitle from the request with the ID 'id'.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult CreateSubtitleFromRequest(int? id)
		{
			SubtitleModel sModel = new SubtitleModel();
			RequestRepository rr = new RequestRepository();
			RequestModel rmodel = new RequestModel();
			int idValue = id.Value;
			rmodel = rr.GetRequestByID(idValue);
			DateTime dt = new DateTime();
			sModel.subtitle.DateAdded = dt.Date+dt.TimeOfDay;
			// VANTAR GENRES Í REQUEST
			sModel.subtitle.Artists     = rmodel.request.Artists;
			sModel.subtitle.YearCreated = rmodel.request.YearCreated;
			sModel.subtitle.Name        = rmodel.request.Name;
			sModel.subtitle.Language    = rmodel.request.Language;
			sModel.subtitle.Description = rmodel.request.Description;
			// Put genres in a bool array
			FillModel(sModel);
			return View("CreateSubtitle", sModel);
		}

		///<summary>
        /// Gets the translation to be edited with the ID 'id'
		///</summary>
        public ActionResult ShowSubtitle(int? id) // THIS ONE IS READY (I think).
        {
			if (id == null)
			{
				return View("Errors/NoSubFound");
			}

            try
			{
				// Convert ID from Nullable int to int.
				int idValue = id.Value;

				// Get the desired item.
				SearchRepository sr = new SearchRepository();
				SubtitleModel result;
				result = sr.GetSubtitleByID(idValue);

				// Fill the empty model variables (genreValue[] and artistsForView).
				FillModel(result);
				
				return View(result);
			}
			catch (NoSubtitleFoundException)
			{
				return View("Errors/NoSubFound");
			}
        }

		/// <summary>
		/// Gets the translation to be edited with the ID subtitleID
		/// </summary> 
		[Authorize]
		[HttpGet]
		public ActionResult EditSubtitle(int? id) // THIS ONE IS READY (I think).
		{
			
			if (id == null)
			{
				return View("Errors/NoSubFound");
			}

            try
            {
				// Convert ID from Nullable int to int.
				int idValue = id.Value;

				// Get the desired item.
				SearchRepository sr = new SearchRepository();
                SubtitleModel result = sr.GetSubtitleByID(idValue);

				// Fill the empty model variables (genreValue[] and artistsForView).
				FillModel(result);
				
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
			editedSub.subtitle.Content = fd["editedText"];
			editedSub.subtitle.Description = fd["description"];

			//editedSub.subtitle.Genres = ;
			//editedSub.subtitle.Artists = ;

			sr.ChangeExistingSubtitle(idValue, editedSub);
			
			// Get the new list
			editedSub = search.GetSubtitleByID(idValue);
			
			// Fill the empty model variables.
			FillModel(editedSub);

			return this.RedirectToAction("ShowSubtitle", new { id = idValue });
		}

		public FileResult Download(int? id)
		{
			if (id == null)
			{
				return null;
			}

			// Convert ID from Nullable int to int.
			int idValue = id.Value;

			SearchRepository sr = new SearchRepository();
			SubtitleModel result;
			try
			{
				// Get the desired subtitle.
				result = sr.GetSubtitleByID(idValue);
			}
			catch (NoSubtitleFoundException)
			{
				return null;
			}

			return File(Encoding.UTF8.GetBytes(result.subtitle.Content), "text/plain", result.subtitle.Name + ".srt");
		}
		/// <summary>
		/// Helper Function. 
		/// <para>Fills in the rest of the model (genreValue[] and artistsForView)</para>
		/// </summary> 
		public void FillModel(SubtitleModel sm)
		{
			// Put genres in a bool array
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

			// Put artists in a string
			foreach (var art in sm.subtitle.Artists)
			{
				if (art != sm.subtitle.Artists.Last())
				{
					sm.artistsForView += art.Name + ", ";
				}
				else
				{
					sm.artistsForView += art.Name;
				}

			}
		}
	}

}