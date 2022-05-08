using Gatekeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace Gatekeeper.Pages
{
    public class CalculationModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Calculation Calculation { get; set; } = new Calculation();

        public IActionResult OnPost()
        {
            Calculation.FutureValue = FutureValue(Calculation);
            Calculation.PresentValue = PresentValue(Calculation);

            return Page();
        }

        private double FutureValue(Calculation values)
        {
            double rate;
            double input;
            int term;

            string rateString = values.FutureRate != null ? Regex.Replace(values.FutureRate, Calculation.Pattern, "") : "";
            string inputString = values.PresentValueInput != null ? Regex.Replace(values.PresentValueInput, Calculation.Pattern, "") : "";
            string termString = values.FutureTerm != null ? Regex.Replace(values.FutureTerm, Calculation.Pattern, "") : "";

            if (double.TryParse(rateString, out rate) && int.TryParse(termString, out term) && double.TryParse(inputString, out input))
            {
                return Math.Round(Financial.FV(rate / 100, term, 0, -1 * input), 2);
            }
            return 0;
        }

        private double PresentValue(Calculation values)
        {
            double rate;
            double input;
            int term;

            string rateString = values.PresentRate != null ? Regex.Replace(values.PresentRate, Calculation.Pattern, "") : "";
            string inputString = values.FutureValueInput != null ? Regex.Replace(values.FutureValueInput, Calculation.Pattern, "") : "";
            string termString = values.PresentTerm != null ? Regex.Replace(values.PresentTerm, Calculation.Pattern, "") : "";

            if (double.TryParse(rateString, out rate) && int.TryParse(termString, out term) && double.TryParse(inputString, out input))
            {
                return Math.Round(Financial.PV(rate / 100, term, 0, -1 * input), 2);
            }
            return 0;
        }
    }
}
