﻿using Skermstafir.Exceptions;
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
using System.Web.Script.Serialization;


namespace Skermstafir.Controllers
{
    public class SubtitleController : Controller
    {

		/// <summary>
		/// GET: Gets the translation to be edited with the ID 'id'
		/// </summary>
		/// <param name="id">ID of the subtitle.</param>
		/// <returns>ActionResult</returns>
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
                // Here we would use "using" for resource management if we had more time.
				SkermData db = new SkermData();
				SearchRepository sr = new SearchRepository(db);
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

		// =======================================================================================
		// CREATE SUBTITLE

		/// <summary>
		/// GET: Creates a new subtitle.
		/// </summary>
		/// <param name="fc">FormCollection from form</param>
		/// <returns>ActionResult</returns>
		[Authorize]
		[HttpGet]
		public ActionResult CreateSubtitle()
		{
			SubtitleModel model = new SubtitleModel();
			return View(model);
		}

        /// <summary>
        /// POST: Creates a new subtitle.
        /// </summary>
		/// <param name="fc">FormCollection from form.</param>
		/// <returns>ActionResult</returns>
        [Authorize]
		[HttpPost, ValidateInput(false)]
        public ActionResult CreateSubtitle(FormCollection fc)
        {
			using(SkermData db = new SkermData())
            {
            SubtitleModel model = new SubtitleModel();
            SearchRepository search = new SearchRepository(db);
            SubtitleRepository subRepo = new SubtitleRepository(db);

            model.subtitle.Username = User.Identity.Name;

            // Set basic info to the new subtitle model
            model.subtitle.Name = fc["title"];

            if (fc["year"] == "")
            {
                model.subtitle.YearCreated = 0;
            }
            else
            {
                model.subtitle.YearCreated = Convert.ToInt32(fc["year"]);
            }

            if (fc["description"] == "")
            {
                model.subtitle.Description = "Ekki skráð.";
            }
            else
            {
                model.subtitle.Description = fc["description"];
            }

            if (fc["link"] != "")
            {
                model.subtitle.Link = fc["link"];
            }

            if (fc["originalText"] == "")
            {
                model.subtitle.Content = "Ekki skráð.";
            }
            else
            {
                model.subtitle.Content = fc["originalText"];
            }

			if (Request.Files.Count > 0)
			{
				var file = Request.Files[0];
				if (file != null && file.ContentLength > 0)
				{
					Stream stream = file.InputStream;
					using (StreamReader br = new StreamReader(stream))
					{
						string sub = br.ReadToEnd();
						model.subtitle.Content = sub;
					}
					}
				}

            if (fc["director"] == "")
            {
                model.subtitle.Director = "Ekki skráð.";
            }
            else
            {
                model.subtitle.Director = fc["director"];
            }
			if (fc["actors"] == "")
			{
				model.subtitle.Actors = "Ekki skráð.";
			}
			else
			{
				model.subtitle.Actors = fc["actors"];
			}

            if (fc["actors"] == "")
            {
                model.subtitle.Actors = "Ekki skráð.";
            }
            else
            {
                model.subtitle.Actors = fc["actors"];
            }

            // Set language of Subtitle model
            if (fc["language"] == "Íslenska")
            {
                model.subtitle.LanguageId = 1;
            }
            if (fc["language"] == "Enska")
            {
                model.subtitle.LanguageId = 2;
            }
            // Set genres of Subtitle model
            for (int i = 1; i < 9; i++)
            {
                if (fc["genre" + i.ToString()] == "on")
                {
					Genre genre = search.GetGenreByID(i);
                    model.subtitle.Genres.Add(genre);
                }
            }
			model.subtitle.DateAdded = DateTime.Now;
            subRepo.AddSubtitle(model);

                return RedirectToAction("ShowSubtitle", new { id = model.subtitle.IdSubtitle });
        }
        }

		/// <summary>
		/// GET: Takes all data from the request with ID 'id' and
		/// puts it into a new subtitle.
		/// </summary>
		/// <param name="id">ID of the request.</param>
		/// <returns>ActionResult</returns>
		[HttpGet]
		[Authorize]
		public ActionResult CreateSubtitleFromRequest(int? id)
		{
            // Parameter value check
            if (!id.HasValue)
            {
                return View("Errors/NoSubFound");
            }
            int idValue = id.Value;

            using (SkermData db = new SkermData())
            {
			SubtitleModel sModel = new SubtitleModel();
			RequestRepository rr = new RequestRepository(db);
			RequestModel rModel = new RequestModel();
            SearchRepository searchRepo = new SearchRepository(db);
                try
                {
			rModel = rr.GetRequestByID(idValue);
                }
                catch(Exception)
                {
                    return View("Errors/NoSubFound");
                }

			sModel.subtitle.YearCreated = rModel.request.YearCreated;
			sModel.subtitle.Name        = rModel.request.Name;
			sModel.subtitle.Language    = rModel.request.Language;
			sModel.subtitle.Description = rModel.request.Description;
			sModel.subtitle.Link		= rModel.request.Link;
			sModel.subtitle.Director    = rModel.request.Director;
			sModel.subtitle.Actors      = rModel.request.Actors;
            // Put genres in a bool array
            foreach (var item in rModel.request.Genres)
            {
                rModel.genreValue[item.IdGenre - 1] = true;
            }
            // Add genres to subtitle model
            for (int i = 0; i < 8; i++)
            {
                if (rModel.genreValue[i] == true)
                {
                    sModel.genreValue[i] = true;
                }
            }

			return View("CreateSubtitle", sModel);
		}
		}

		/// <summary>
		/// POST: Creates a subtitle from the request with the ID 'id',
		/// and then deletes the request.
		/// </summary>
		/// <param name="id">ID of the request.</param>
		/// <param name="fc">FormCollection from form.</param>
		/// <returns>ActionResult</returns>
		[HttpPost]
		[Authorize, ValidateInput(false)]
		public ActionResult CreateSubtitleFromRequest(int? id, FormCollection fc)
		{
            if (!id.HasValue)
            {
                return View("Errors/NoSubFound");
            }
            using (SkermData db = new SkermData())
            {
			RequestRepository reqRepo = new RequestRepository(db);
			int idValue = id.Value;
			reqRepo.DeleteRequest(idValue);
			return CreateSubtitle(fc);
		}
		}



		/// <summary>
		/// GET: Gets the translation to be edited with the ID 'id'
		/// </summary> 
		/// <param name="id">ID of the subtitle.</param>
		/// <returns>ActionResult</returns>
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
                // Here we would use "using" for resource management if we had more time.
				SkermData db = new SkermData();
				SearchRepository sr = new SearchRepository(db);
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
		
		/// <summary>
		/// POST: Takes the form data submitted and sends it to the repository.
		/// </summary>
		/// <param name="id">ID of the subtitle.</param>
		/// <param name="fd">FormCollection returned from form.</param>
		/// <param name="sub">Subtitle returned from form.</param>
		/// <returns>ActionResult</returns>
		// Not validating input may not be good practice.
		[Authorize]
		[HttpPost, ValidateInput(false)]
		public ActionResult EditSubtitle(int? id, FormCollection fd, Subtitle sub)
		{
            if (!id.HasValue)
            {
                return View("Error/NoSubFound");
            }
			int idValue = id.Value;

            using (SkermData db = new SkermData())
            {
			SubtitleModel editedSub = new SubtitleModel();
			SearchRepository seaR = new SearchRepository(db);
			SubtitleRepository subR = new SubtitleRepository(db);
			
			// Get the subtitle
                try
                {
			editedSub = seaR.GetSubtitleByID(idValue);
                }
                catch (NoSubtitleFoundException)
                {
                    return View("Errors/NoSubFound");
                }


			// Change the subtitle
            if (fd["year"] == "")
            {
                editedSub.subtitle.YearCreated = 0;
            }
            else
            {
                editedSub.subtitle.YearCreated = Convert.ToInt32(fd["year"]);
            }

            if (fd["originalText"] == "")
            {
                editedSub.subtitle.Content = "Ekki skráð";
            }
            else
            {
                editedSub.subtitle.Content = fd["originalText"];
            }

            if (fd["editedText"] == "")
            {
                editedSub.subtitle.EditContent = "Ekki skráð";
            }
            else
            {
                editedSub.subtitle.EditContent = fd["editedText"];
            }

            if (fd["description"] == "")
            {
                editedSub.subtitle.Description = "Ekki skráð";
            }
            else
            {
                editedSub.subtitle.Description = fd["description"];
            }

            if (fd["link"] == "")
            {
                editedSub.subtitle.Link = "Ekki skráð.";
            }
            else
            {
                editedSub.subtitle.Link = fd["link"];
            }

            if (fd["director"] == "")
            {
                editedSub.subtitle.Director = "Ekki skráð";
            }
            else
            {
                editedSub.subtitle.Director = fd["director"];
            }

            if (fd["actor"] == "")
            {
                editedSub.subtitle.Actors = "Ekki skráð.";
            }
            else
            {
                editedSub.subtitle.Actors = fd["actors"];
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
			// Finally we update the subtitle.
			subR.ChangeExistingSubtitle(idValue, editedSub);
			
			return RedirectToAction("ShowSubtitle", new { id = idValue });
		}
		}

		/// <summary>
		/// Deletes the subtitle with the ID 'id'
		/// </summary>
		/// <param name="id">ID of the subtitle.</param>
		/// <returns>ActionResult</returns>
		[Authorize]
        public ActionResult DeleteSubtitle(int? id)
        {
            // Parameter value check
            if (!id.HasValue)
            {
                return View("Errors/NoSubFound");
            }
            int idValue = id.Value;

            using (SkermData db = new SkermData())
            {
                SubtitleRepository subRepo = new SubtitleRepository(db);
                SearchRepository serRepo = new SearchRepository(db);
                Subtitle toBeRemoved = serRepo.GetSubtitleByID(idValue).subtitle;

                // Existence check
                if (toBeRemoved == null)
                {
                    return View("Errors/NoSubFound");
                }
                string ownerName = serRepo.GetSubtitleByID(idValue).subtitle.Username;
                
                // Authorization check
                if (ownerName != User.Identity.GetUserName())
                {
                    return View("Errors/NoSubFound");
                }

                subRepo.DeleteSubtitle(idValue);
                return RedirectToAction("Manage", "Account");
            }
        }

		/// <summary>
		/// POST: Adds upvote to subtitle.
		/// </summary>
		/// <param name="subid">ID of the subtitle to upvote.</param>
		/// <returns>ActionResult</returns>
		[HttpPost]
		public ActionResult UpvoteSubtitle(int subid)
		{
			string userName = User.Identity.GetUserName();
			string userId = User.Identity.GetUserId();
            // Here we would use "using" for resource management if we had more time.
			SkermData db = new SkermData();
			SearchRepository sr = new SearchRepository(db);
			SubtitleModel sub = sr.GetSubtitleByID(subid);
			Subtitle subtitle = sub.subtitle;
			Vote vote = sr.GetVoteByUserID(userId);
			if (vote == null)
			{
				vote = new Vote();
				sr.AddVoteToUserId(vote, userId);
			}

			// Check for user.
			if (userName == "")
			{
				// User is not logged in.
				var noUser = new { Exists = 3 };
				return Json(noUser, JsonRequestBehavior.AllowGet);
			}
			else if (userName == subtitle.Username)
			{
				var subOwner = new { Exists = 2 };
				return Json(subOwner, JsonRequestBehavior.AllowGet);
			}
			//------------------------------------------------------
			// Check for vote.
			if (sr.VoteContainsSubtitle(vote, subtitle))
			{
				sr.RemoveVoteFromSubtite(vote, subtitle);
				var existsYes = new { Exists = 1 };
				return Json(existsYes, JsonRequestBehavior.AllowGet);
			}
			else
			{
				sr.AddVoteToSubtite(vote, subtitle);
				var existsNo = new { Exists = 0 };
				return Json(existsNo, JsonRequestBehavior.AllowGet);
			}

		}

		// =======================================================================================
		// COMMENTS
		/// <summary>
		/// Posts a comment to the database and redirects to the subtitle that was commented on.
		/// </summary>
		/// <param name="form">Data from the form.</param>
		/// <returns>ActionResult</returns>
		[Authorize]
		public ActionResult Comment(FormCollection form) 
        {
            // Here we would use "using" for resource management if we had more time.
			SkermData db = new SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			Subtitle sub = searchRep.GetSubtitleByID(Convert.ToInt32(form["id"])).subtitle;
			Comment com = new Comment();
			com.Content = form["CommentText1"];
			com.Username = User.Identity.GetUserName();
			com.DateCreated = DateTime.Now;
			searchRep.AddCommentToSub(com, sub);
			return RedirectToAction("ShowSubtitle", new { id = sub.IdSubtitle });
		}

		/// <summary>
		/// Posts a comment to the database and redirects to the subtitle that was commented on.
		/// </summary>
		/// <param name="id">ID of the comment</param>
		/// <param name="id">ID of the subtitle that was commented on.</param>
		/// <returns>ActionResult</returns>
        [Authorize]
        public ActionResult DeleteComment(int? id, int? subID)
		{
            // Parameter value check
            if (!id.HasValue || !subID.HasValue)
			{
                return View("Errors/NoSubFound");
			}

			int idValue = id.Value;
            int idRedirect = subID.Value;
            using (SkermData db = new SkermData())
            {
                SearchRepository serRepo = new SearchRepository(db);
                Comment toBeRemoved = serRepo.GetCommentById(idValue);

                // Existence check
                if (toBeRemoved == null)
			{
                    return View("Errors/NoSubFound");
			}
                string ownerName = toBeRemoved.Username;

                // Authorization check
                if (ownerName != User.Identity.GetUserName())
			{
                    return View("Errors/NoSubFound");
			}
                serRepo.DeleteComment(idValue);
                return RedirectToAction("ShowSubtitle", new { id = idRedirect });
		}
        }

		// =======================================================================================
		// DOWNLOAD
		/// <summary>
		/// Downloads the subtitle with the ID 'id'
		/// </summary>
		/// <param name="id">ID of the subtitle.</param>
		/// <returns>FileResult</returns>
		public FileResult Download(int? id)
		{
			if (id == null)
			{
				return File(Encoding.UTF8.GetBytes("Þýðing fannst ekki."), "text/plain", "FannstEkki.srt");
			}

			// Convert ID from Nullable int to int.
			int idValue = id.Value;
            // Here we would use "using" for resource management if we had more time.
			SkermData db = new SkermData();
			SearchRepository sr = new SearchRepository(db);
			SubtitleModel result;

			try
			{
				// Get the desired subtitle.
				result = sr.GetSubtitleByID(idValue);
			}
			catch (NoSubtitleFoundException)
			{
				return File(Encoding.UTF8.GetBytes("Þýðing fannst ekki."), "text/plain", "FannstEkki.srt");
			}

			if (result.subtitle.EditContent == null)
			{
				return File(Encoding.UTF8.GetBytes("Ekki hefur verið byrjað á þýðingunni."), "text/plain", result.subtitle.Name + ".srt");
			}

			sr.AddDownloadToSubtitle(result.subtitle);
			return File(Encoding.UTF8.GetBytes(result.subtitle.EditContent), "text/plain", result.subtitle.Name + ".srt");
		}

		// =======================================================================================
		// HELPER FUNCTIONS

		/// <summary>
		/// Helper Function. Fills in the genreValue[].
		/// </summary> 
		/// <param name="sm">SubtitleModel to fill in to.</param>
		/// <returns>void</returns>
		public void FillModel(SubtitleModel sm)
		{
			// Put genres in a bool array
			foreach (var item in sm.subtitle.Genres)
			{
				sm.genreValue[item.IdGenre - 1] = true;
            }
        }
	}
}