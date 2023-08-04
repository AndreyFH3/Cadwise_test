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

        public List<Bill> GiveBills(int money, bool bigValue)
        {
            List<Bill> bills = new List<Bill>();
            int value = 0;
            while (value != money)
                {
                    if (bigValue)
                    {
                        foreach (Bill b in _bills)
                        {
                            if(b.Value == BillValue.OneThousand || b.Value == BillValue.TwoThousand || b.Value == BillValue.FiveThousand)
                            {
                                
                            }
                        }
                    }
                    else
                    {
                        foreach (Bill bill in _bills)
                        {

                        }
                    }
                }
            return bills;
        }
        

    }
}
