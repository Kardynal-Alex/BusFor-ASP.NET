using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFor.Models.DataModel
{
    public class PassengerDocument
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string SeriesN { get; set; }
        public DateTime Validity { get; set; }
        public string Sex { get; set; }
        public DateTime DateRace { get; set; }
    }
}
