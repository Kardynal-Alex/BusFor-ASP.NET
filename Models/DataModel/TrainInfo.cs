using System;
using System.ComponentModel.DataAnnotations;

namespace BusFor.Models.DataModel
{
    public class TrainInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter date of dispatch")]
        [Display(Name = "Date of dispatch")]
        public DateTime Date1 { get; set; }
        [Required(ErrorMessage = "Enter date of arrival")]
        [Display(Name = "Date of arrival")]
        public DateTime Date2 { get; set; }
        [Required(ErrorMessage = "Enter time of dispatch")]
        [Display(Name = "Time of dispatch")]
        public TimeSpan Time1 { get; set; }
        [Required(ErrorMessage = "Enter time of arrival")]
        [Display(Name = "Time of arrival")]
        public TimeSpan Time2 { get; set; }
        [Required(ErrorMessage = "Enter location of dispatch")]
        [Display(Name = "Location of dispatch")]
        public string Location1 { get; set; }
        [Required(ErrorMessage = "Enter location of arrival")]
        [Display(Name = "Location of arrival")]
        public string Location2 { get; set; }
        [Required(ErrorMessage = "Enter number of platform")]
        [Range(1, int.MaxValue, ErrorMessage = "Out of range")]
        [Display(Name = "Number of platform")]
        public int Platform { get; set; }
        //[Required(ErrorMessage = "Enter number of Coupe(1-2-3-7)")]
        [Display(Name = "Enter number of Coupe(1-2-3-7)")]
        public string NumberOfCoupe { get; set; }
        //[Required(ErrorMessage = "Enter number of PlatzKarte(4-5-6-8)")]
        [Display(Name = "Enter number of PlatzKarte(4-5-6-8)")]
        public string NumberOfPlatzKarte { get; set; }
        [Required(ErrorMessage = "Enter CoupePrice")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Out of range")]
        public double CoupePrice { get; set; }
        [Required(ErrorMessage = "Enter PlatzKartePrice")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Out of range")]
        public double PlatzKartePrice { get; set; }
    }
}
