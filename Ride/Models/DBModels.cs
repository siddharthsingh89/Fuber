using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ride.Models
{
    public class RideContext : DbContext
    {   
        public DbSet<Fare> Fares { get; set; }
        public DbSet<Ride> Rides { get; set; }

        public string DbPath { get; }

        public RideContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Ride.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Fare
    {
        public int FareId { get; set; }
        public int UserId { get; set; }
        public string FareName { get; set; }
        public decimal FareAmount { get; set; }
        public string Source {  get; set; }
        public string Destination { get; set; }
        public DateTime EstimatedTimeOfArrival { get; set; }
    }

    public class Ride
    {
        public int RideId { get; set; }
        public string RiderId { get; set; }
        public string DriverId { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public DateTime RideDate { get; set; }
        public int FareId { get; set; }
        public string Status { get; set; }
    }
}
