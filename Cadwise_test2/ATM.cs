using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cadwise_test2
{
    internal class ATM
    {
        public int BalanceCash
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

        public int Tens => dictionary[BillValue.Ten];
        public int Fifty => dictionary[BillValue.Fifty];
        public int OneHundred => dictionary[BillValue.OneHundred];
        public int TwoHundred=> dictionary[BillValue.TwoHundred];
        public int FiveHundred => dictionary[BillValue.FiveHundred];
        public int OneThousand => dictionary[BillValue.OneThousand];
        public int TwoThousand => dictionary[BillValue.TwoHundred];
        public int FiveThousand => dictionary[BillValue.FiveThousand];

        public int tens => dictionary[BillValue.Ten];
        private Dictionary<BillValue, int> dictionary = new Dictionary<BillValue, int>();
        public List<Bill> _bills;

        public ATM(int startCapacity, int maxCapacity = 1024)
        {
            _bills = BillGenerator.GenerateBills(startCapacity, maxCapacity);
            CreateDictionary();
        }

        private void CreateDictionary()
        {
            foreach (Bill b in _bills)
            {
                if (!dictionary.ContainsKey(b.Value))
                    dictionary.Add(b.Value, 1);
                else
                    dictionary[b.Value]++;
            }
        }

        public void AddMoney(List<Bill> bills)
        {
            foreach(Bill bill in bills)
            {
                _bills.Add(bill);
                dictionary[bill.Value]++;
            }
        }

        public int GetMultiplayer()
        {
            if((Tens >= 5 && Fifty >= 1)  || Tens >= 10)
                return 10;
            else if(Fifty >= 2 || OneHundred >= 1)
                return 100;
            else if(FiveHundred >= 1 || OneHundred >= 5 || (TwoHundred >= 1 && OneHundred >=3) || (TwoHundred >= 2 && OneHundred >= 1))
                return 500;
            else
                return 1000;

        }

        public List<Bill> CashOut(int money, bool? bigValue)
        {
            List<Bill> bills = new List<Bill>();
            int tens = money % 100;
            int hundred = money % 1_000 - tens;
            int thousand = money % 1_000_000 - hundred - tens;
            if(bigValue == true)
            {
                bills.AddRange(FindBill(ref thousand, BillValue.FiveThousand));
                bills.AddRange(FindBill(ref thousand, BillValue.TwoThousand));
                bills.AddRange(FindBill(ref thousand, BillValue.OneThousand));

                if (thousand >= 1000)
                    hundred += thousand;

                bills.AddRange(FindBill(ref hundred, BillValue.FiveHundred));
                bills.AddRange(FindBill(ref hundred, BillValue.TwoHundred));
                bills.AddRange(FindBill(ref hundred, BillValue.OneHundred));
                
                if(hundred >= 100)
                    tens += hundred;
                bills.AddRange(FindBill(ref tens, BillValue.Fifty));
                bills.AddRange(FindBill(ref tens, BillValue.Ten));
            }
            else
            {
                bills.AddRange(FindBill(ref thousand, BillValue.OneThousand));
                bills.AddRange(FindBill(ref thousand, BillValue.TwoThousand));
                bills.AddRange(FindBill(ref thousand, BillValue.FiveThousand));

                if (thousand >= 1000)
                    hundred += thousand;

                bills.AddRange(FindBill(ref hundred, BillValue.OneHundred));
                bills.AddRange(FindBill(ref hundred, BillValue.TwoHundred));
                bills.AddRange(FindBill(ref hundred, BillValue.FiveHundred));

                if (hundred >= 100)
                    tens += hundred;

                bills.AddRange(FindBill(ref tens, BillValue.Fifty));
                bills.AddRange(FindBill(ref tens, BillValue.Ten));
            }
            int value = 0;
            foreach (Bill bill in bills)
            {
                value+= (int)bill.Value;
            }
            if (value == money)
                return bills;
            else
            {
                MessageBox.Show("Ошибка!\nНевозможно выдать средства!");
                _bills.AddRange(bills);
                return null;
            }
        }

        private List<Bill> FindBill(ref int number, BillValue bv)
        {
            List<Bill> bills = new List<Bill>();

            int iterations = number / (int)bv;
            for (int i = 0; i < iterations; i++)
            {
                Bill b = _bills.Find(x => x.Value == bv);
                if (b == null)
                    break;
                number -= (int)b.Value;
                dictionary[b.Value]--;
                bills.Add(b);
                _bills.Remove(b);
            }
            return bills;
        }

    }
}
