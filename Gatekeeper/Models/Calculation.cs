using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Gatekeeper.Models
{
    public class Calculation
    {
        //public ExpenseOrAsset NewAsset { get; set; } = new ExpenseOrAsset();
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


        public List<ExpenseOrAsset> Expenses { get; set; } = new List<ExpenseOrAsset>
        {
            new ExpenseOrAsset { Description = "Mortgage", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Food", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Utilities", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Vacation", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Going Out", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Gas", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Other", Amount = "$0.00" },
        };
        public List<ExpenseOrAsset> Assets { get; set; } = new List<ExpenseOrAsset>
        {
            new ExpenseOrAsset { Description = "Bank", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "401k", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Investments", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Other", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Other", Amount = "$0.00" },
            new ExpenseOrAsset { Description = "Other", Amount = "$0.00" }
        };
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double TotalAssets
        {
            get
            {
                return Assets.Select(x => x.Value).Sum();
            }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double TotalExpenses
        {
            get
            {
                return Expenses.Select(x => x.Value).Sum();
            }
        }
        public static string Pattern = @"[^\d |\.|\-]";
    }

    public class ExpenseOrAsset
    {
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public double Value {
            get
            {
                return Amount != null && double.TryParse(Regex.Replace(Amount, Calculation.Pattern, ""), out double r) ? r : 0;
            }
        }
        //public ExpenseOrAssetEnum Type { get; set; }
    }

    //public enum ExpenseOrAssetEnum
    //{
    //    Expense = 0,
    //    Asset = 10
    //}
}
