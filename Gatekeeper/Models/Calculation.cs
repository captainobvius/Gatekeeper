using System.ComponentModel.DataAnnotations;

namespace Gatekeeper.Models
{
    public class Calculation
    {
        public List<ExpenseOrAsset> Expenses { get; set; } = new List<ExpenseOrAsset>();
        public List<ExpenseOrAsset> Assets { get; set; } = new List<ExpenseOrAsset>();
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

    public class ExpenseOrAsset
    {
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public ExpenseOrAssetEnum Type { get; set; }
    }

    public enum ExpenseOrAssetEnum
    {
        Expense = 0,
        Asset = 10
    }
}
