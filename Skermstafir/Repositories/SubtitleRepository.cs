using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;

namespace Skermstafir.Repositories
{
    public class SubtitleRepository
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
			using (SkermData db = new SkermData())
			{
				Subtitle toBeChanged = (from item in db.Subtitles
										where item.IdSubtitle == id
										select item).Single();

				toBeChanged.YearCreated = editSub.subtitle.YearCreated;
				toBeChanged.Content     = editSub.subtitle.Content;
				toBeChanged.Description = editSub.subtitle.Description;
				
				db.SaveChanges();
			}
        }
    }
}