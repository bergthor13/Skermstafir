using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
//using System.Data.Entity;

namespace Skermstafir.Repositories
{
    public class SubtitleRepository
    {
        // Add a subtitlemodel object to database
        public void AddSubtitle(SubtitleModel model)
        {
            using (SkermData db = new SkermData())
            {
                db.Subtitles.Add(model.subtitle);
                db.SaveChanges();
            }
        }
        // delete a specific subtitle from database
        public void DeleteSubtitle(int id)
        {
            using (SkermData db = new SkermData())
            {
                Subtitle toBeDeleted = (from item in db.Subtitles
                                        where item.IdSubtitle == id
                                        select item).Single();
                db.Subtitles.Remove(toBeDeleted);
                db.SaveChanges();
            }
        }

        // change an existing subtitle entry in the database
        public void ChangeExistingSubtitle(int id, SubtitleModel editSub)
        {
            using (SkermData db = new SkermData())
            {
                Subtitle toBeChanged = (from item in db.Subtitles
                                        where item.IdSubtitle == id
                                        select item).Single();
                //db.Entry(editSub.subtitle).State = EntityState.Modified;
                toBeChanged = editSub.subtitle;
                db.SaveChanges();
            }
        }
    }
}