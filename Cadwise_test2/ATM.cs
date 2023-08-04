using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal class ATM
    {
        private int MoneyAmount
        {
            get
            {
                int amount = 0;
                foreach (Bill b in _bills)
                {
                    amount += (int)b.Value;
                }
                return amount;
            }
        }

        List<Bill> _bills;

        public ATM(int startCapacity, int maxCapacity = 512)
        {
            _bills = BillGenerator.GenerateBills(startCapacity, maxCapacity);
        }


        public void AddMoney(Bill[] bills)
        {
            foreach(Bill bill in bills)
            {
                _bills.Add(bill);
            }
        }

        public List<Bill> GiveBills(int money)
        {

        }
        
    }
}
