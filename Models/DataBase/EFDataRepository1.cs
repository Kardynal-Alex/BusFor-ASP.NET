﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public class EFDataRepository1:IDataRepository1
    {
        private EFDatabaseContext context;
        public EFDataRepository1(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public async Task CreateRace(TrainInfo trainInfo)
        {
            context.TrainInfos.Add(trainInfo);
            await context.SaveChangesAsync();
        }
        public async Task UpdateRace(TrainInfo trainInfo)
        {
            TrainInfo t = context.TrainInfos.Find(trainInfo.Id);
            t.Date1 = trainInfo.Date1;
            t.Date2 = trainInfo.Date2;
            t.Time1 = trainInfo.Time1;
            t.Time2 = trainInfo.Time2;
            t.Location1 = trainInfo.Location1;
            t.Location2 = trainInfo.Location2;
            t.Platform = trainInfo.Platform;
            t.NumberOfCoupe = trainInfo.NumberOfCoupe;
            t.NumberOfPlatzKarte = trainInfo.NumberOfPlatzKarte;
            t.CoupePrice = trainInfo.CoupePrice;
            t.PlatzKartePrice = trainInfo.PlatzKartePrice;
            context.TrainInfos.Update(t);
            await context.SaveChangesAsync();
        }
        public async Task DeleteRace(int id)
        {
            context.TrainInfos.Remove(new TrainInfo { Id = id });
            await context.SaveChangesAsync();
        }
        public IQueryable<TrainInfo> GetAllRaces() => context.TrainInfos;
        public TrainInfo GetRaceById(int id) => context.TrainInfos.Find(id);
        public IQueryable<TrainInfo> GetTodaysRaces()=> context.TrainInfos.Where(x => x.Date1 == DateTime.Now.Date).Select(x => x);
        public IQueryable<TrainInfo> FindRace(string Location1, string Location2, DateTime Date)
        {
            return context.TrainInfos.Where(x => x.Location1 == Location1 && x.Location2 == Location2 && x.Date1 == Date).Select(x => x);
        }
    }
}
