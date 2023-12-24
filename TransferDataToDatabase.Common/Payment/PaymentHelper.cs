using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TransferDataToDatabase.Common.Payment
{
    public static class PaymentHelper
    {
        // ••••••••••••
        // DEFINATIONS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region Variables

        private static readonly int[] Formula = { 2, 3, 4, 5, 6, 7 };
        private static int _sum;

        #endregion

        // ••••••••••••
        // METHODS     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region private static int CalculateSum(this string value)
        private static void CalculateSum(this string value)
        {
            var integerList = new List<long>();
            for (var i = 0; i < value.Count(); i++)
            {
                integerList.Add(long.Parse(value.Substring(i, 1)));
            }
            for (var i = 0; i < integerList.Count; i++)
            {
                _sum += Convert.ToInt32(integerList[integerList.Count - 1 - i] * Formula[i]);
            }
        }
        #endregion

        #region private int CalculateRadix11(this string value)
        private static int CalculateRadix11(this string value)
        {
            _sum = 0;

            if (value.Length <= 6)
            {
                CalculateSum(value);
            }
            else
            {
                do
                {
                    if (value.Length > 6)
                    {
                        CalculateSum(value.Substring(value.Length - 6));
                        value = value.Substring(0, value.Length - 6);
                    }
                    else
                    {
                        CalculateSum(value);
                        break;
                    }



                } while (value.Any());
            }

            if ((_sum % 11 == 0) || _sum % 11 == 1)
            {
                return 0;
            }
            return 11 - _sum % 11;
        }
        #endregion

        #region public static string ReceiptNumber(this string digit8, string payCode)
        public static string ReceiptNumber(this string digit8, string payCode)
        {
            if (payCode == "") return "";
            var controlDigit = CalculateRadix11(digit8 + payCode);
            return Convert.ToInt64(digit8 + payCode + controlDigit).ToString("D13");
        }

        #endregion

        #region public static string PaymentNumber(this string receiptNumber, string price1000, string year1, string period2)

        public static string PaymentNumber(this string receiptNumber, string price1000, string year1, string period2)
        {
            if (receiptNumber == "") return "";
            long receiptNo;

            long.TryParse(receiptNumber, out receiptNo);

            var controlDigit1 = CalculateRadix11(price1000 + year1 + period2);
            var controlDigit2 =
                CalculateRadix11(receiptNo.ToString(CultureInfo.InvariantCulture) + price1000 + year1 + period2 +
                                 controlDigit1.ToString(CultureInfo.InvariantCulture));
            return
                Convert.ToInt64(price1000 + year1 + period2 + controlDigit1 + controlDigit2).ToString("0000000000000");
        }

        #endregion
    }
}
