using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmltocsv
{
    class BundleLine
    {
        
            public String CurrencyCode;
            public int Nominal;
            public int Quantity;
            public int Amount;
            public bool Rejected;

            public string asCsvRow()
            {
                return string.Format("{0}, {1}, {2}, {3}, {4}", this.CurrencyCode, this.Nominal, this.Quantity, this.Amount, this.Rejected).ToString();
            }
        }
    }

