using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal class Wallet
    {
        public List<Bill> _bills = new List<Bill>(100);

        public Wallet(int _10, int _50, int _100, int _200, int _500, int _1000, int _2000, int _5000)
        {
            _bills.AddRange(BillGenerator.GenerateBills(_10, BillValue.Ten));
            _bills.AddRange(BillGenerator.GenerateBills(_50, BillValue.Fifty));
            _bills.AddRange(BillGenerator.GenerateBills(_100, BillValue.OneHundred));
            _bills.AddRange(BillGenerator.GenerateBills(_200, BillValue.TwoHundred));
            _bills.AddRange(BillGenerator.GenerateBills(_500, BillValue.FiveHundred));
            _bills.AddRange(BillGenerator.GenerateBills(_1000, BillValue.OneThousand));
            _bills.AddRange(BillGenerator.GenerateBills(_2000, BillValue.TwoThousand));
            _bills.AddRange(BillGenerator.GenerateBills(_5000, BillValue.FiveThousand));
        }
    }
}
