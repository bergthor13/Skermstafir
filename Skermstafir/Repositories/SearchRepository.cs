﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
using Skermstafir.Exceptions;

namespace Skermstafir.Repositories
{
    public class SearchRepository
    {
        // queries database to get the newest starting from start and ending at end bot inclusive
        public SubtitleModelList GetSubtitleByNewest(int start, int end)
        {
            SubtitleModelList model = new SubtitleModelList();
            SkermData db = new SkermData();
            model.modelList = (from sub in db.Subtitles
                                   orderby sub.DateAdded
                                   select sub).Skip(start).Take(end - start).ToList();
            return model;
        }

        // queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
        public SubtitleModelList GetSubtitleByMostPopular(int start, int end)
        {
            SubtitleModelList model = new SubtitleModelList();
            SkermData db = new SkermData();
                model.modelList = (from sub in db.Subtitles
                                   orderby sub.Votes.Count
                                   select sub).Skip(start).Take(end - start).ToList();
            return model;
        }

        // queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
        public SubtitleModelList GetSubtitlesByUserID(String userID)
        {
            SubtitleModelList model = new SubtitleModelList();
            SkermData db = new SkermData();
            model.modelList = (from sub in db.Subtitles
                               where sub.AspNetUsers.FirstOrDefault().Id == userID
                               select sub).ToList();
            return model;
        }


        // query database to get a specific subtitle
        public SubtitleModel GetSubtitleByID(int id)
        {
            SubtitleModel model = new SubtitleModel();
            SkermData db = new SkermData();
                model.subtitle = (from sub in db.Subtitles
                                  where sub.IdSubtitle == id
                                  select sub).SingleOrDefault();

				if (model.subtitle == null)
				{
                    throw new NoSubtitleFoundException();
				}

            return model;
        }

        // query database to get subtitles by language starting at index start and ending at index end both inclusive
        public SubtitleModelList GetSubtitleByLanguage(string language, int start, int end)
        {
            SubtitleModelList model = new SubtitleModelList();
            SkermData db = new SkermData();
                model.modelList = (from sub in db.Subtitles
                                   where sub.Language.Name == language
                                   select sub).Skip(start).Take(end - start).ToList();
            return model;
        }

        // query database to get subtitles by creation year starting from start and ending with end both inclusive
        public SubtitleModelList GetSubtitleByCreationDate(int startYear, int endYear, int start, int end)
        {
            SubtitleModelList model = new SubtitleModelList();
            SkermData db = new SkermData();
                model.modelList = (from sub in db.Subtitles
                                   where sub.YearCreated >= startYear && sub.YearCreated <= endYear
                                   select sub).Skip(start).Take(end - start).ToList();
            return model;
        }

        
	}
}