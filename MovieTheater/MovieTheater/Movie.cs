//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieTheater
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public Movie()
        {
            this.RoomMovie = new HashSet<RoomMovie>();
        }
    
        public int Movie_ID { get; set; }
        public string Movie_Name { get; set; }
        public int Duration { get; set; }
        public string PictureURL { get; set; }
        public string IMDB_Link { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Subtitle { get; set; }
        public double Ratings { get; set; }
        public bool Active_Indicator { get; set; }
        public System.DateTime Update_Datetime { get; set; }
    
        public virtual ICollection<RoomMovie> RoomMovie { get; set; }
    }
}
