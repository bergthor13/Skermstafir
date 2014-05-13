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
        // Add a subtitlemodel object to database
        public void AddSubtitle(SubtitleModel model)
        {
            SkermData db = new SkermData();
            db.Subtitles.Add(model.subtitle);
            db.SaveChanges();
        }
        // Delete a specific subtitle from database
        public void DeleteSubtitle(int id)
        {
            SkermData db = new SkermData();
            Subtitle toBeDeleted = (from item in db.Subtitles
                                    where item.IdSubtitle == id
                                    select item).Single();
                db.Subtitles.Remove(toBeDeleted);
                db.SaveChanges();
        }

        // Change an existing subtitle entry in the database
        public void ChangeExistingSubtitle(int id, SubtitleModel editSub)
        {
			SkermData db = new SkermData();
			Subtitle toBeChanged = (from item in db.Subtitles
									where item.IdSubtitle == id
									select item).Single();
			// Copy all data over
			toBeChanged.LanguageId  = editSub.subtitle.LanguageId;
			toBeChanged.DirectorId  = editSub.subtitle.DirectorId;
			toBeChanged.Name        = editSub.subtitle.Name;
			toBeChanged.Description = editSub.subtitle.Description;
			toBeChanged.YearCreated = editSub.subtitle.YearCreated;
			toBeChanged.Content     = editSub.subtitle.Content;
			toBeChanged.EditContent = editSub.subtitle.EditContent;
			toBeChanged.DateAdded   = editSub.subtitle.DateAdded;
			toBeChanged.Link		= editSub.subtitle.Link;

			db.SaveChanges();	
        }

		public Director GetDirectorByName(string dir)
		{
			SkermData db = new SkermData();
			Director check = (from item in db.Directors
							  where item.Name == dir
							  select item).SingleOrDefault();

			if (check == null)
			{
				return null;
			}
			else
			{
				return check;
			}
		}

		public void AddGenreToSubtitle(Genre gen, Subtitle sub)
		{
			SkermData db = new SkermData();
			sub.Genres.Add(gen);
			db.SaveChanges();
		}

		public void RemoveGenreToSubtitle(Genre gen, Subtitle subtitle)
		{
			SkermData db = new SkermData();
			subtitle.Genres.Remove(gen);
			db.SaveChanges();
		}
	}
}