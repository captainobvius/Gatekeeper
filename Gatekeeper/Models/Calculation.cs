using System.ComponentModel.DataAnnotations;

namespace Gatekeeper.Models
{
    public class Calculation
    {
        public string? FutureValueInput { get; set; } = "$1,388.23";
        public string? PresentTerm { get; set; } = "10";
        public string? PresentRate { get; set; } = "6.0%";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double FutureValue { get; set; } = 0;
        public string? PresentValueInput { get; set; } = "$48,000.00";
        public string? FutureTerm { get; set; } = "10";
        public string? FutureRate { get; set; } = "3.0%";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double PresentValue { get; set; } = 0;
    }
}
