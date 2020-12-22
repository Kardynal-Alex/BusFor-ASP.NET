using System;
using System.ComponentModel.DataAnnotations;

namespace BusFor.Models.DataModel
{
    public class PassengerDocument
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Date of birth")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter Nationality")]
        public string Nationality { get; set; }
        [MaxLength(8)]
        [Required(ErrorMessage = "Enter Series and Nomer of document")]
        public string SeriesN { get; set; }
        [Required(ErrorMessage = "Select Validity Date of your document")]
        public DateTime Validity { get; set; }
        [Required(ErrorMessage = "Select Sex")]
        public string Sex { get; set; }
        public DateTime DateRace { get; set; }
    }
}
