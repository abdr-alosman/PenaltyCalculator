using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CountryWeekendDay
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
        public int WeekDayId { get; set; }
        [ForeignKey("WeekDayId")]
        public WeekDay? WeekDay { get; set; }    

    }
}
