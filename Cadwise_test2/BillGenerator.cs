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
                int rand = random.Next(8);
                switch (rand)
                {
                    case 0:
                        bills.Add(new Bill(BillValue.Ten));
                        break;
                    case 1:
                        bills.Add(new Bill(BillValue.Fifty));
                        break;
                    case 2:
                        bills.Add(new Bill(BillValue.OneHundred));
                        break;
                    case 3:
                        bills.Add(new Bill(BillValue.TwoHundred));
                        break;
                    case 4:
                        bills.Add(new Bill(BillValue.FiveHundred));
                        break;
                    case 5:
                        bills.Add(new Bill(BillValue.OneThousand));
                        break;
                    case 6:
                        bills.Add(new Bill(BillValue.TwoThousand));
                        break;
                    case 7:
                        bills.Add(new Bill(BillValue.FiveThousand));
                        break;

                }
            }
            return bills;
        }
    }
}
