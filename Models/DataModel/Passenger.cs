using System;
using System.ComponentModel.DataAnnotations;

namespace BusFor.Models.DataModel
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter passenger`s name")]
        [Display(Name = "Passenger`s name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter passenger`s surname")]
        [Display(Name = "Passenger`s surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter passenger`s age")]
        [Range(1, 120, ErrorMessage = "Out of range")]
        [Display(Name = "Passenger`s age")]
        public int Age { get; set; }
        public int Place { get; set; }
        public DateTime DateRace { get; set; }
        public int BusInfoId { get; set; }
    }
}
