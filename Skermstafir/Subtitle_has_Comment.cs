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
    
    public partial class Subtitle_has_Comment
    {
        public int IdSubtitle_has_Comment { get; set; }
        public int SubtitleId { get; set; }
        public int CommentId { get; set; }
    
        public virtual Comment Comment { get; set; }
        public virtual Subtitle Subtitle { get; set; }
    }
}
