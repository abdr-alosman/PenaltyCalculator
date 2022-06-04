using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter country name")]
        [StringLength(70)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter currency code")]
        [StringLength(10)]
        public string? CurrencyCode { get; set; }
        public double PenaltyAmount { get; set; }
        public List<NationalReligiousDay>? NationalReligiousDays { get; set; }
        public List<CountryWeekendDay>? CountryWeekendDays { get; set; }
        public Country()
        {
            NationalReligiousDays = new List<NationalReligiousDay>();
            CountryWeekendDays=new List<CountryWeekendDay>();
        }

    }
}
