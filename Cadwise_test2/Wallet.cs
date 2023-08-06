using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal class Wallet
    {
        public List<Bill> bills = new List<Bill>(100);

        public int Capacity => bills.Capacity;

        public Wallet(int _10, int _50, int _100, int _200, int _500, int _1000, int _2000, int _5000)
        {
            bills.AddRange(BillGenerator.GenerateBills(_10, BillValue.Ten));
            bills.AddRange(BillGenerator.GenerateBills(_50, BillValue.Fifty));
            bills.AddRange(BillGenerator.GenerateBills(_100, BillValue.OneHundred));
            bills.AddRange(BillGenerator.GenerateBills(_200, BillValue.TwoHundred));
            bills.AddRange(BillGenerator.GenerateBills(_500, BillValue.FiveHundred));
            bills.AddRange(BillGenerator.GenerateBills(_1000, BillValue.OneThousand));
            bills.AddRange(BillGenerator.GenerateBills(_2000, BillValue.TwoThousand));
            bills.AddRange(BillGenerator.GenerateBills(_5000, BillValue.FiveThousand));
        }
    }
}
