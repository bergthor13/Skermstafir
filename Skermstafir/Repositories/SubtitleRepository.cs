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
		public SkermData db;

		public SubtitleRepository(SkermData connection) {
			db = connection;
		}

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
            toBeChanged.Director    = editSub.subtitle.Director;
            toBeChanged.Actors      = editSub.subtitle.Actors;
            
			//toBeChanged.Genres = editSub.subtitle.Genres;
            
			db.SaveChanges();	
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

		public void AddCommentToSub(Comment com, Subtitle sub) {
			sub.Comments.Add(com);
			db.SaveChanges();
		}

        // Delete the comment with the 'id'.
        public void DeleteComment(int id)
        {
            Comment toBeRemoved = (from comment in db.Comments
                                   where comment.IdComment == id
                                   select comment).FirstOrDefault();
            db.Comments.Remove(toBeRemoved);
            db.SaveChanges();
        }
	}
}