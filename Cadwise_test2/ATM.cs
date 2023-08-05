using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    internal class ATM
    {
        public int AmountCash
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

        public List<Bill> _bills;

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

        public List<Bill> CashOut(int money, bool? bigValue)
        {
            List<Bill> bills = new List<Bill>();
            int value = 0;
            int tens = money % 100;
            int hundreed = money % 1_000 - tens;
            int thousand = money % 1_000_000 - hundreed - tens;
            if(bigValue == true)
            {
                for (int i = 0; i <= _bills.Count; i++)
                {
                    value += 1;
                    //need take bills which can give amount = money;
                    //calculate how can it be take;
                    //from maxToLow if bigValue = true;
                    //from LowToMax if bigValue = false;
                }
            }
            else
            {
                for(int i =_bills.Count - 1; i>=0; i--)
                {

                }
            }
            return bills;
        }
        

    }
}
