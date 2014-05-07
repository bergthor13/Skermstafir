using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;

namespace Skermstafir.Repositories
{
    public class SubtitleRepository
    {
        // gets top "howMany" subtitles by newest
        public List<SubtitleModel> GetSubtitleByNewest(int howMany)
        {
            List<SubtitleModel> modelList = new List<SubtitleModel>();
            // here is dummy code for integration purposes
            for (int i = 0; i < howMany; i++)
            {
                SubtitleModel dummy = new SubtitleModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.language = "Íslenska";
                dummy.votes = 99;
                dummy.yearCreated = 2014;
                dummy.Artists.Add("None");
                dummy.downloads = 25;
                dummy.content = "Some bullshit";
                dummy.dateCreated = DateTime.Now;
                modelList.Add(dummy);
            }
            return modelList;
        }
    }
}