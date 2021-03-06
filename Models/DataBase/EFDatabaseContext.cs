﻿using Microsoft.EntityFrameworkCore;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public class EFDatabaseContext:DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opt) : base(opt) { }

        public DbSet<BusInfo> BusInfos { get; set; }
        public DbSet<Passenger> BusPassengers { get; set; }
        public DbSet<TrainInfo> TrainInfos { get; set; }
        public DbSet<TrainPassenger> TrainPassengers { get; set; }
        public DbSet<PlaneInfo> PlaneInfos { get; set; }
        public DbSet<PlanePassenger> PlanePassengers { get; set; }
        public DbSet<PassengerDocument> PassengerDocuments { get; set; }
    }
}
