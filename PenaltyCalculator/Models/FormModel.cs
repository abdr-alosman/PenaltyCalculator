using System.ComponentModel.DataAnnotations;

namespace PenaltyCalculator.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "Please select country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please enter checked out date")]
        public DateTime checkedOut_Date { get; set; }
        [Required(ErrorMessage = "Please enter returned date")]
        public DateTime return_Date { get; set; }
        
    }
}
