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
using System.Web.Security;
using Microsoft.AspNet.Identity;

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
            SearchRepository search = new SearchRepository();
            SubtitleRepository sr = new SubtitleRepository();

            // Get current logged in user
            var logUser = User.Identity.GetUserName();
            
            // Set info to the new subtitle
            model.subtitle.Name = fc["title"];
            model.subtitle.YearCreated = Convert.ToInt32(fc["year"]);
            model.subtitle.Description = fc["description"];
            model.subtitle.Director.Name = fc["director"];
            model.subtitle.Link = fc["link"];
            model.subtitle.Content = fc["original-text"];

            string actors = fc["actors"];
            String[] actorers = actors.Split(',');
            foreach(var item in actorers)
            {
                Actor temp = new Actor();
                temp.Name = item;
                model.subtitle.Actors.Add(temp);
            }

            for (int i = 0; i < 8; i++)
            {
                if (fc["genre" + i.ToString()] == "on")
                {
                    Genre temp = new Genre();
                    model.subtitle.Genres.Add(temp);
                }
            }

            if (fc["languages"] == "Íslenska")
            {
                model.subtitle.Language.Name = "Íslenska";
            }
            if (fc["languages"] == "Enska")
            {
                model.subtitle.Language.Name = "Enska";
            }

            sr.AddSubtitle(model);

            return this.RedirectToAction("ShowSubtitle", new { id = model.subtitle.IdSubtitle });
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
			RequestModel rModel = new RequestModel();
			int idValue = id.Value;
			rModel = rr.GetRequestByID(idValue);
			sModel.subtitle.Genres      = rModel.request.Genres;
			sModel.subtitle.Actors      = rModel.request.Actors;
			sModel.subtitle.YearCreated = rModel.request.YearCreated;
			sModel.subtitle.Name        = rModel.request.Name;
			sModel.subtitle.Language    = rModel.request.Language;
			sModel.subtitle.Description = rModel.request.Description;
			sModel.subtitle.Link		= rModel.request.Link;
			// Put genres in a bool array
			FillModel(sModel);

			// Put genres in a bool array
			foreach (var item in rModel.request.Genres)
			{
				rModel.genreValue[item.IdGenre - 1] = true;
			}

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
			SearchRepository seaR = new SearchRepository();
			SubtitleRepository subR = new SubtitleRepository();
			
			// Get the subtitle
			editedSub = seaR.GetSubtitleByID(idValue);

			// Change the subtitle
			editedSub.subtitle.YearCreated = Convert.ToInt32(fd["year"]);
			editedSub.subtitle.Content     = fd["originalText"];
			editedSub.subtitle.EditContent = fd["editedText"];
			editedSub.subtitle.Description = fd["description"];

			// Gets the director object specified in the 'director' textbox in the view.
			string directorName = fd["director"];
			Director director = subR.GetDirectorByName(directorName);
			// If the director is not found, we create a new director with that name.
			if (director == null) {
				Director newDir = new Director();
				newDir.Name = directorName;
				seaR.AddDirector(newDir);
				editedSub.subtitle.DirectorId = newDir.IdDirector;
				// Else we change the director of the subtitle.
			} else {
				editedSub.subtitle.DirectorId = director.IdDirector;
			}

			// Add the genres selected to the subtitle.
			for (int i = 1; i <= 8; i++)
			{
				if (fd["genre" + i.ToString()] == "on")
				{
					Genre gen = seaR.GetGenreByID(i);
					if (gen != null)
					{
						subR.AddGenreToSubtitle(gen, editedSub.subtitle);
					}
				}
				else
				{
					Genre gen = seaR.GetGenreByID(i);
					if (gen != null)
					{
						subR.RemoveGenreToSubtitle(gen, editedSub.subtitle);

					}
				}
			}

			/*
			string actors = fd["actors"];
			string actorName = "";
			String[] actorers = actors.Split(',');

			/*foreach (var item in actorers)
			{
				if (item[0] == ' ')
				{
					actorName = item.Substring(1, item.Length-1);
				}
				Actor temp = new Actor();
				temp.Name = actorName;

				Actor actor = subR.GetActorByName(actorName);
				// If the director is not found, we create a new director with that name.
				if (actor == null)
				{
					Actor newAct = new Actor();
					newAct.Name = actorName;
					seaR.AddActor(newAct);
					//editedSub.subtitle.DirectorId = newAct.IdActor;
					// Else we change the director of the subtitle.
				}
				else
				{
					//editedSub.subtitle.Actor = director.IdActor;
				}

			}*/

			// Finally we update the subtitle.
			subR.ChangeExistingSubtitle(idValue, editedSub);
			
			return RedirectToAction("ShowSubtitle", new { id = idValue });
		}

		public ActionResult UpvoteSubtitle(int subid)
		{
			string userName = User.Identity.GetUserName();
			string userId = User.Identity.GetUserId();

			if (userName == "")
			{
				// User is not logged in.
				object ob = new { Exists = 2 };
				return View(Json(ob, JsonRequestBehavior.AllowGet));
			}

			SearchRepository sr = new SearchRepository();
			Vote vote = sr.GetVoteByUserID(userId);
			SubtitleModel sub = sr.GetSubtitleByID(subid);
			Subtitle subtitle = sub.subtitle;

			if (sr.VoteContainsSubtitle(vote, subtitle))
			{
				object ob = new { Exists = 1 };
				return View(Json(ob, JsonRequestBehavior.AllowGet));
			}
			else
			{
				subtitle.Votes.Add(vote);
			}
		
			object ob2 = new { id2 = 0 };
			return View(Json(ob2, JsonRequestBehavior.AllowGet));
		}

		// Downloads the srt file.
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

			return File(Encoding.UTF8.GetBytes(result.subtitle.EditContent), "text/plain", result.subtitle.Name + ".srt");
		}
		/// <summary>
		/// Helper Function. Fills in the rest of the model (genreValue[] and artistsForView)
		/// </summary> 
		public void FillModel(SubtitleModel sm)
		{

			// Put genres in a bool array
			foreach (var item in sm.subtitle.Genres)
			{
				 sm.genreValue[item.IdGenre-1] = true;
			}

			// Put artists in a string
			foreach (var act in sm.subtitle.Actors)
			{
				if (act != sm.subtitle.Actors.Last())
				{
					sm.actorsForView += act.Name + ", ";
				}
				else
				{
					sm.actorsForView += act.Name;
				}

			}
		}
	}

}