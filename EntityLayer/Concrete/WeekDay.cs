using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WeekDay
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name of day")]
        [StringLength(50)]
        public string? Name { get; set; }
        public List<CountryWeekendDay>? CountryWeekendDays { get; set; }
    }
}
