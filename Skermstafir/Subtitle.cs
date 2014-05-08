//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Skermstafir
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subtitle
    {
        public Subtitle()
        {
            this.Artists = new HashSet<Artist>();
            this.Comments = new HashSet<Comment>();
            this.Genres = new HashSet<Genre>();
            this.Votes = new HashSet<Vote>();
            this.AspNetUsers = new HashSet<AspNetUser>();
        }
    
        public int IdSubtitle { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> YearCreated { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
