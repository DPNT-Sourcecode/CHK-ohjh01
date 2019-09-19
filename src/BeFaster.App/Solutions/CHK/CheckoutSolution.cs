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
                skulist.Add(skus.Substring(i, 1));

            skulist.Sort();

            var skusWithQuantities = ParseSkus(skulist);

            ApplyCrossSkuDeals(skusWithQuantities);

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

        private static void ApplyCrossSkuDeals(Dictionary<string, int>  skusWithQuantities)
        {
            // 2E get one B free
            if (skusWithQuantities.ContainsKey("B") && skusWithQuantities.ContainsKey("E"))
            {
                int bcount = skusWithQuantities["B"];
                int ecount = skusWithQuantities["E"];

                int freebs = ecount / 2;
                bcount -= freebs;
                if (bcount < 0)
                    bcount = 0;

                skusWithQuantities["B"] = bcount;
            }

            // 3N get one M free
            if (skusWithQuantities.ContainsKey("N") && skusWithQuantities.ContainsKey("M"))
            {
                int ncount = skusWithQuantities["N"];
                int mcount = skusWithQuantities["M"];

                int freems = ncount / 3;
                mcount -= freems;
                if (mcount < 0)
                    mcount = 0;

                skusWithQuantities["M"] = mcount;
            }

            // 3R get one Q free
            if (skusWithQuantities.ContainsKey("Q") && skusWithQuantities.ContainsKey("R"))
            {
                int qcount = skusWithQuantities["Q"];
                int rcount = skusWithQuantities["R"];

                int freeqs = rcount / 3;
                qcount -= freeqs;
                if (qcount < 0)
                    qcount = 0;

                skusWithQuantities["Q"] = qcount;
            }

            // Multi STXYZ deal
            int stxyzCount = 0;
            // find total combined deals
            foreach (string s in new[] { "S", "T", "X", "Y", "Z" })
            {
                if (skusWithQuantities.ContainsKey(s))
                    stxyzCount += skusWithQuantities[s];
            }
            int stxyzDeals = stxyzCount / 3;
            skusWithQuantities["1"] = stxyzDeals;   // special tag to record number of deals
            int numberToRemove = stxyzDeals * 3;

            // now scan in value order to reduce counts according to deals
            foreach (string s in new[] { "Z", "S", "T", "Y", "X" })
            {
                if (numberToRemove > 0)
                {
                    if (skusWithQuantities.ContainsKey(s))
                    {
                        int thisCount = skusWithQuantities[s];
                        int removeCount = Math.Min(thisCount, numberToRemove);
                        skusWithQuantities[s] = thisCount - removeCount;
                        numberToRemove -= removeCount;
                    }
                }
            }
        }

        private static Dictionary<string, int> ParseSkus(List<string> skulist)
        {
            var skus = new Dictionary<string, int>();
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
                        skus[last] = count;
                    count = 1;
                    last = s;
                }
            }

            skus[last] = count;

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
                case "F":
                    {
                        int specials = qty / 3;
                        int rem = qty - 3 * specials;
                        return rem * 10 + specials * 20;
                    }
                case "G":
                    return qty * 20;
                case "H":
                    {
                        // try 10x deals first
                        int specials5 = qty / 10;
                        qty -= 10 * specials5;
                        int sum = specials5 * 80;

                        // see if any 5x deals left
                        int specials = qty / 5;
                        int rem = qty - 5 * specials;
                        return sum + rem * 10 + specials * 45;
                    }
                case "I":
                    return qty * 35;
                case "J":
                    return qty * 60;
                case "K":
                    {
                        int specials = qty / 2;
                        int rem = qty - 2 * specials;
                        return rem * 70 + specials * 120;
                    }
                case "L":
                    return qty * 90;
                case "M":
                    return qty * 15;
                case "N":
                    return qty * 40;
                case "O":
                    return qty * 10;
                case "P":
                    {
                        int specials = qty / 5;
                        int rem = qty - 5 * specials;
                        return rem * 50 + specials * 200;
                    }
                case "Q":
                    {
                        int specials = qty / 3;
                        int rem = qty - 3 * specials;
                        return rem * 30 + specials * 80;
                    }
                case "R":
                    return qty * 50;
                case "S":
                    return qty * 20;
                case "T":
                    return qty * 20;
                case "U":
                    {
                        int specials = qty / 4;
                        int rem = qty - 4 * specials;
                        return rem * 40 + specials * 120;
                    }
                case "V":
                    {
                        // try 3x deals first
                        int specials3 = qty / 3;
                        qty -= 3 * specials3;
                        int sum = specials3 * 130;

                        // see if any 2x deals left
                        int specials = qty / 2;
                        int rem = qty - 2 * specials;
                        return sum + rem * 50 + specials * 90;
                    }
                case "W":
                    return qty * 20;
                case "X":
                    return qty * 17;
                case "Y":
                    return qty * 20;
                case "Z":
                    return qty * 21;
                case "1":
                    return qty * 45;

                default:
                    throw new Exception("Invalid sku");
            }
        }
    }
}
