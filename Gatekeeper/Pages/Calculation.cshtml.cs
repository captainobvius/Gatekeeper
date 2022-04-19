using Gatekeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

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
            if (values.FutureRate != null && values.FutureTerm != null && values.PresentValueInput != null)
            {
                return Math.Round(Financial.FV(values.FutureRate.Value, values.FutureTerm.Value, 0, -1 * values.PresentValueInput.Value), 2);
            }
            return 0;
        }

        private double PresentValue(Calculation values)
        {
            if (values.PresentRate != null && values.PresentTerm != null && values.FutureValueInput != null)
            {
                return Math.Round(Financial.PV(values.PresentRate.Value, values.PresentTerm.Value, 0, -1 * values.FutureValueInput.Value), 2);
            }
            return 0;
        }
    }
}
