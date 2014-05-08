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
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.id = 1;
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 94;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 20000000;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                dummy.user = "YOOOUUUU!!!!!";
                value.Add(dummy);
            }
            return value;
        }

        // queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
        public SubtitleModelList GetSubtitleByMostPopular(int start, int end)
        {
            SubtitleModelList modelList = new SubtitleModelList();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.id = 1;
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
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
                SubtitleModel dummy = new SubtitleModel();
                dummy.id = 1;
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
            }
            return modelList;
        }


        // query database to get a specific subtitle
        public SubtitleModel GetSubtitleByID(int id)
        {
            SubtitleModel dummy = new SubtitleModel();
            dummy.id = 1;
            dummy.name = "Anchorman 2, The Legend Continues";
            dummy.language = "Íslenska";
            dummy.votes = 99;
            dummy.yearCreated = 2014;
            dummy.artists.Add("None");
            dummy.downloads = 25;
            dummy.content = "Some bullshit";
            dummy.dateCreated = DateTime.Now;
            dummy.user = "YOOOUUUU!!!!!";
            return dummy;
        }

        // query database to get subtitles by language starting at index start and ending at index end both inclusive
        public SubtitleModelList GetSubtitleByLanguage(string Language, int start, int end)
        {
            SubtitleModelList modelList = new SubtitleModelList();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.id = 1;
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
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
                SubtitleModel dummy = new SubtitleModel();
                dummy.id = 1;
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
            }
            return modelList;
        }

        
	}
}