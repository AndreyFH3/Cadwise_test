using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal static class BillGenerator
    {
        public static List<Bill> GenerateBills(int startCapacity, int maxCapacity)
        {
            List<Bill> bills = new List<Bill>();
            if (startCapacity > maxCapacity)
            {
                startCapacity = maxCapacity;
            }
            Random random = new Random();
            for (int i = 0; i < startCapacity; i++)
            {
                //int rand = random.Next(8);
                float rand = random.NextSingle();
                switch (rand)
                {
                    case < 0.125f:
                        bills.Add(new Bill(BillValue.Ten));
                        break;
                    case < .25f:
                        bills.Add(new Bill(BillValue.Fifty));
                        break;
                    case <.375f:
                        bills.Add(new Bill(BillValue.OneHundred));
                        break;
                    case <.5f:
                        bills.Add(new Bill(BillValue.TwoHundred));
                        break;
                    case <.625f:
                        bills.Add(new Bill(BillValue.FiveHundred));
                        break;
                    case <.75f:
                        bills.Add(new Bill(BillValue.OneThousand));
                        break;
                    case < .875f:
                        bills.Add(new Bill(BillValue.TwoThousand));
                        break;
                    case < 1:
                        bills.Add(new Bill(BillValue.FiveThousand));
                        break;

                }
            }
            return bills;
        }

        public static List<Bill> GenerateBills(int amount, BillValue value)
        {
            List<Bill> bills = new List<Bill>();    
            for(int i = 0; i < amount; i++)
            {
                bills.Add(new Bill(value));
            }
            return bills;
        }
    }
}
