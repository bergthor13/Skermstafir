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
    
    public partial class Request_has_Genre
    {
        public int IdRequest_has_Genre { get; set; }
        public int RequestId { get; set; }
        public int GenreId { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Request Request { get; set; }
    }
}
