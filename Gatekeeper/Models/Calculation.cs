using System.ComponentModel.DataAnnotations;

namespace Gatekeeper.Models
{
    public class Calculation
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double FutureValue { get; set; } = 0;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double? FutureValueInput { get; set; } = 0;
        public int? FutureTerm { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:p2}")]
        public double? FutureRate { get; set; } = 0;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double PresentValue { get; set; } = 0;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double? PresentValueInput { get; set; } = 0;
        public int? PresentTerm { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:p2}")]
        public double? PresentRate { get; set; } = 0;
    }
}
