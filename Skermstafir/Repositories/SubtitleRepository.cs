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
            using (SkermData db = new SkermData())
            {
                // Add the subtitle itself
                db.Subtitles.Add(model.subtitle);
                // Add the artists
                // Connect the subtitle with the genres
                // Connect the subtitle with his author
            }
        }

        // delete a specific subtitle from database
        public void DeleteSubtitle(int id)
        {

        }

        // change an existing subtitle entry in the database
        public void ChangeExistingSubtitle(int id, SubtitleModel editSub)
        {

        }
    }
}