using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFor.Models.DataModel
{
    public class TrainPassenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Van { get; set; }
        public int Place { get; set; }
        public DateTime DateRace { get; set; }
        public string Email { get; set; }
        public string Mode { get; set; }
        public bool IsPostel { get; set; }
        public int TrainInfoId { get; set; }
    }
}
