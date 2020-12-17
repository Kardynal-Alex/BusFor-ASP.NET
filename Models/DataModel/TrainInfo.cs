using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFor.Models.DataModel
{
    public class TrainInfo
    {
        public int Id { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public TimeSpan Time1 { get; set; }
        public TimeSpan Time2 { get; set; }
        public string Location1 { get; set; }
        public string Location2 { get; set; }
        public int Platform { get; set; }
        public string NumberOfCoupe { get; set; }
        public string NumberOfPlatzKarte { get; set; }
        public double CoupePrice { get; set; }
        public double PlatzKartePrice { get; set; }
    }
}
