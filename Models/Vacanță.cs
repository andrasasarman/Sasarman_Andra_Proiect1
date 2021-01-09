using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sasarman_Andra_Proiect1.Models
{
    public class Vacanță
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Destinația trebuie să fie de forma 'Țară Oraș'"), Required, StringLength(50, MinimumLength = 3)]

        [Display(Name = "Destinația vacanței")]
        public string Destinație { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        public string Plecare { get; set; }
        [Range(1, 3000)]
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Preț($)")]
        public decimal Preț { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Dată plecare")]

        public DateTime Date { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Durată sejur")]
        public string Durata { get; set; }
        [Display(Name = "Numar persoane")]
        public int NrPers { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        
    }
}
