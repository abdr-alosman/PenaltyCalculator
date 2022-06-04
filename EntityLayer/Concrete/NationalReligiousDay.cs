using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NationalReligiousDay
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter national or religious day name")]
        [StringLength(70)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter date of national day")]
        [Display(Name = "Date of national/religious day")]
        [DataType(DataType.Date)]
        public DateTime DayDate { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
    }
}
