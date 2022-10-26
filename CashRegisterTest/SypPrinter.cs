using CashRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterTest
{
    public class SypPrinter : Printer
    {
        public bool HasPrintedV1 { get; set; }

        public override void Print(string content)
        {
            this.HasPrintedV1 = true;
        }
    }
}
