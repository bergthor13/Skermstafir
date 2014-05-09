using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;

namespace Skermstafir.Repositories
{
    public class SearchRepository
    {
        // queries database to get the newest starting from start and ending at end bot inclusive
        public SubtitleModelList GetSubtitleByNewest(int start, int end)
        {
            SubtitleModelList value = new SubtitleModelList();
            return value;
        }

        // queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
        public SubtitleModelList GetSubtitleByMostPopular(int start, int end)
        {
            SubtitleModelList modelList = new SubtitleModelList();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
            }
            return modelList;
        }

        // queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
        public SubtitleModelList GetSubtitleByUser(String username, int start, int end)
        {
            SubtitleModelList modelList = new SubtitleModelList();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
            }
            return modelList;
        }


        // query database to get a specific subtitle
        public SubtitleModel GetSubtitleByID(int id)
        {
            SubtitleModel dummy = new SubtitleModel();
<<<<<<< HEAD
<<<<<<< HEAD
            dummy.subtitle = (from sub in db.Subtitles
                              where sub.IdSubtitle == id
                              select sub).SingleOrDefault();
            db.Subtitles.Add()
=======
>>>>>>> parent of 0b03134... Dagur er snillingur
=======
>>>>>>> parent of 0b03134... Dagur er snillingur
            return dummy;
        }

        // query database to get subtitles by language starting at index start and ending at index end both inclusive
        public SubtitleModelList GetSubtitleByLanguage(string Language, int start, int end)
        {
            SubtitleModelList modelList = new SubtitleModelList();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
            }
            return modelList;
        }

        // query database to get subtitles by creation year starting from start and ending with end both inclusive
        public SubtitleModelList GetSubtitleByCreationDate(int startYear, int endYear, int start, int end)
        {
            SubtitleModelList modelList = new SubtitleModelList();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
            }
            return modelList;
        }

        
	}
}