using System;
using System.ComponentModel.DataAnnotations;

namespace BusFor.Models.DataModel
{
    public class PlanePassenger
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter passenger`s name")]
        [Display(Name = "Passenger`s name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter passenger`s surname")]
        [Display(Name = "Passenger`s surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorect email")]
        public string Email { get; set; }
        public int IntPlace { get; set; }
        public string StringPlace { get; set; }
        public DateTime DateRace { get; set; }
        public string Mode { get; set; }
        public int PlaneInfoId { get; set; }
        public int PassengerDocumentId { get; set; }

        public PassengerDocument PassengerDocument { get; set; }
    }
}
