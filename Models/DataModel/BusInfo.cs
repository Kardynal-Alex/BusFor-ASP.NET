using System;
namespace BusFor.Models.DataModel
{
    public class BusInfo
    {
        public int Id { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public TimeSpan Time1 { get; set; }
        public TimeSpan Time2 { get; set; }
        public string Location1 { get; set; }
        public string Location2 { get; set; }
        public double Price { get; set; }
        public string Platform { get; set; }
    }
}
