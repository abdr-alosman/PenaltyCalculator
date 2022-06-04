namespace PenaltyCalculator.Models
{
    public class CalculatePenaltyModel
    {
        public int BusinessDays { get; set; }
        public double Penalty { get; set; }
        public string CountryCurrencey { get; set; }
        public DateTime CheckDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public string Country { get; set; }
    }
}
