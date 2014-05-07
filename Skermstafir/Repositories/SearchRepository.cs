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
        public List<SubtitleModel> GetSubtitleByNewest(int start, int end)
        {
            List<SubtitleModel> modelList = new List<SubtitleModel>();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                modelList.Add(dummy);
            }
            return modelList;
        }

        // queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
        public List<SubtitleModel> GetSubtitleByMostPopular(int start, int end)
        {
            List<SubtitleModel> modelList = new List<SubtitleModel>();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                modelList.Add(dummy);
            }
            return modelList;
        }

        // query database to get all subtitles created by a specific user starting at index start and ending at index end both inclusive
        public List<SubtitleModel> GetSubtitleByUser(String username, int start, int end)
        {
            List<SubtitleModel> modelList = new List<SubtitleModel>();
            return modelList;
        }

        // query database to get a specific subtitle
        public SubtitleModel GetSubtitleByID(int id)
        {
            SubtitleModel dummy = new SubtitleModel();
            dummy.name = "Anchorman 2, The Legend Continues";
            dummy.language = "Íslenska";
            dummy.votes = 99;
            dummy.yearCreated = 2014;
            dummy.artists.Add("None");
            dummy.downloads = 25;
            dummy.content = "Some bullshit";
            dummy.dateCreated = DateTime.Now;
            return dummy;
        }

        // query database to get subtitles by language starting at index start and ending at index end both inclusive
        public List<SubtitleModel> GetSubtitleByLanguage(string Language, int start, int end)
        {
            List<SubtitleModel> modelList = new List<SubtitleModel>();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                modelList.Add(dummy);
            }
            return modelList;
        }

        // query database to get subtitles by creation year starting from start and ending with end both inclusive
        public List<SubtitleModel> GetSubtitleByCreationDate(int startYear, int endYear, int start, int end)
        {
            List<SubtitleModel> modelList = new List<SubtitleModel>();
            // here is dummy code for integration purposes
            for (int i = 0; i < end - start; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                modelList.Add(dummy);
            }
            return modelList;
        }

		internal List<SubtitleModel> GetSubtitleByCreationName(int p1, int p2)
		{
			throw new NotImplementedException();
		}

		internal List<SubtitleModel> GetSubtitleByUser(int p1, int p2)
		{
			throw new NotImplementedException();
		}
	}
}