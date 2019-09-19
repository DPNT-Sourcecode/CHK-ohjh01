using System;
using System.Collections.Generic;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            if (string.IsNullOrEmpty(skus))
                return 0;

            // first group SKUs together by creating and sorting a list

            var skulist = new List<string>();
            for (int i = 0; i < skus.Length; i++)
            {
                skulist.Add(skus.Substring(i, 1));
            }

            skulist.Sort();

            var skusWithQuantities = ParseSkus(skulist);

            int sum = 0;
            try
            {
                foreach (var skuWithQuantity in skusWithQuantities)
                    sum += CalculatePrice(skuWithQuantity.Key, skuWithQuantity.Value);
            }
            catch (Exception)
            {
                return -1;
            }

            return sum;
        }

        private static List<KeyValuePair<string, int>> ParseSkus(List<string> skulist)
        {
            var skus = new List<KeyValuePair<string, int>>();
            string last = null;
            int count = 0;

            foreach (string s in skulist)
            {
                if (s == last)
                {
                    count++;
                }
                else
                {
                    if (last != null)
                        skus.Add(new KeyValuePair<string, int>(last, count));
                    count = 1;
                    last = s;
                }
            }

            skus.Add(new KeyValuePair<string, int>(last, count));

            return skus;
        }

        private static int CalculatePrice(string sku, int qty)
        {
            switch (sku)
            {
                case "A":
                    {
                        // try 5x deals first
                        int specials5 = qty / 5;
                        qty -= 5 * specials5;
                        int sum = specials5 * 200;

                        // see if any 3x deals left
                        int specials = qty / 3;
                        int rem = qty - 3 * specials;
                        return sum + rem * 50 + specials * 130;
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
                case "E":
                    return qty * 40;

                default:
                    throw new Exception("Invalid sku");
            }
        }
    }
}
