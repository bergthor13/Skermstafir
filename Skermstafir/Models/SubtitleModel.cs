using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class SubtitleModel
    {
        public Subtitle subtitle { get; set; }
        public ApplicationUser user { get; set; }
        public List<Genre> genres { get; set; }
        public List<Artist> artists { get; set; }
        public List<Comment> comments { get; set; }
        public int votes { get; set; }

        public SubtitleModel()
        {
            genres = new List<Genre>();
            artists = new List<Artist>();
            comments = new List<Comment>();
        }
    }
}