﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MovieTheaterEntities : DbContext
    {
        public MovieTheaterEntities()
            : base("name=MovieTheaterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingDetail> BookingDetail { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomMovie> RoomMovie { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<SeatMovie> SeatMovie { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Theater> Theater { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
