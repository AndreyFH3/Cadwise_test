using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal class Wallet
    {
        List<Bill> _bills = new List<Bill>(64);

        public Wallet(int startCapacity, int MaxCapacity = 64)
        { 
            _bills = BillGenerator.GenerateBills(startCapacity, MaxCapacity);
        }
    }
}
