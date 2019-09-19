using System;
using System.Collections.Generic;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            // first group SKUs together by creating and sorting a list
            skus = skus.ToUpper();
            var skulist = new List<string>();
            for (int i =0; i < skus.Length; i++)
            {
                skulist.Add(skus.Substring(i, 1));
            }

            skulist.Sort();

            string last = null;
            int count = 0;
            int sum = 0;

            try
            {
                foreach (string s in skulist)
                {
                    if (s == last)
                    {
                        count++;
                    }
                    else
                    {
                        sum += CalculatePrice(last, count);
                        count = 0;
                        last = s;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

            sum += CalculatePrice(last, count);

            return sum;
        }

        private static int CalculatePrice(string sku, int qty)
        {
            if (qty == 0)
                return 0;

            switch (sku)
            {
                case "A":
                    {
                        int specials = qty / 3;
                        int rem = qty - 3 * specials;
                        return rem * 50 + specials * 130;
                    }
                case "B":
                    {
                        int specials = qty / 2;
                        int rem = qty - 2 * specials;
                        return rem * 30 + specials * 45;
                    }
                case "C":
                    return qty * 20;
                case "D":
                    return qty * 15;

                default:
                    throw new Exception("Invalid sku");
            }
        }
    }
}
