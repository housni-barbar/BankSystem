using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemProject
{
    public static class BankHelper
    {
        public const double TaxRate = 0.5;
        public static double ConvertToLocalCurrency(double usdAmount , double exchangeRate)
        {
            return usdAmount * exchangeRate;
        }
        public static bool IsValidAccountNumber(string accNo)
        {
            return !string.IsNullOrEmpty(accNo) && accNo.StartsWith("ACC-"); // يتحقق ان رقم الحساب ليس فارغ ويبدأ ب-ACC
        }
    }
}
