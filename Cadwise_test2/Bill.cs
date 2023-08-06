using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadwise_test2
{
    public class Bill
    {
        public BillValue Value { get; init; }
        public Bill(BillValue value)
        {
            Value = value;
        }   
    }
}
