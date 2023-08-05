using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal class Wallet
    {
        public List<Bill> _bills = new List<Bill>(64);
        public int AmountCash { 
            get 
            {
                int i = 0;
                foreach (Bill item in _bills)
                {
                    i += (int)item.Value;
                }
                return i;
            }
        }

        public Wallet(int startCapacity, int MaxCapacity = 64)
        { 
            _bills = BillGenerator.GenerateBills(startCapacity, MaxCapacity);
        }

        public void AddMoney(List<Bill> bills)
        {

        }

        public void RemoveMoeny(int amount)
        {

        }
    }
}
