using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
using Skermstafir.Interfaces;

namespace Skermstafir.Repositories

	
{
    public class SubtitleRepository : ISubtitleRepository
    {
		public SkermData db = new SkermData();
        // Add a SubtitleModel object to database
        public void AddSubtitle(SubtitleModel model)
        {
            db.Subtitles.Add(model.subtitle);
            db.SaveChanges();
        }

        // Delete a specific subtitle from database
        public void DeleteSubtitle(int id)
        {
            Subtitle toBeDeleted = (from item in db.Subtitles
                                    where item.IdSubtitle == id
                                    select item).Single();
                db.Subtitles.Remove(toBeDeleted);
                db.SaveChanges();
        }

        // Change an existing subtitle entry in the database
        public void ChangeExistingSubtitle(int id, SubtitleModel editSub)
        {
			Subtitle toBeChanged = (from item in db.Subtitles
									where item.IdSubtitle == id
									select item).Single();
			// Copy all data over
			toBeChanged.LanguageId  = editSub.subtitle.LanguageId;
			toBeChanged.Name        = editSub.subtitle.Name;
			toBeChanged.Description = editSub.subtitle.Description;
			toBeChanged.YearCreated = editSub.subtitle.YearCreated;
			toBeChanged.Content     = editSub.subtitle.Content;
			toBeChanged.EditContent = editSub.subtitle.EditContent;
			toBeChanged.DateAdded   = editSub.subtitle.DateAdded;
			toBeChanged.Link		= editSub.subtitle.Link;
			//toBeChanged.Genres = editSub.subtitle.Genres;

			int i = db.SaveChanges();	
        }

		public void AddGenreToSubtitle(Genre gen, Subtitle sub)
		{
			sub.Genres.Add(gen);
			db.SaveChanges();
		}

		public void RemoveGenreToSubtitle(Genre gen, Subtitle sub)
		{
			sub.Genres.Remove(gen);
			db.SaveChanges();
		}

		public Actor GetActorByName(string actorName)
		{
			Actor act = (from item in db.Actors
						   where item.Name == actorName
						   select item).SingleOrDefault();
			return act;
		}

		public void AddCommentToSub(Comment com, Subtitle sub) {
			sub.Comments.Add(com);
			db.SaveChanges();
		}
	}
}