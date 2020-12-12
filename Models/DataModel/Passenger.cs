using System;
namespace BusFor.Models.DataModel
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Place { get; set; }
        public DateTime Date { get; set; }
        public int BusInfoId { get; set; }
    }
}
