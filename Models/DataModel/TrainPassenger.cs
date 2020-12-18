using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusFor.Models.DataModel
{
    public class TrainPassenger
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter passenger`s name")]
        [Display(Name = "Passenger`s name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter passenger`s surname")]
        [Display(Name = "Passenger`s surname")]
        public string Surname { get; set; }
        public int Van { get; set; }
        public int Place { get; set; }
        public DateTime DateRace { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorect email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mode P or C")]
        public string Mode { get; set; }
        public bool IsPostel { get; set; }
        public int TrainInfoId { get; set; }
    }
}
