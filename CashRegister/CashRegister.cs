using System;

namespace CashRegister
{
	public class CashRegister
	{
		private readonly Printer printer;

		public CashRegister(Printer printer)
		{
			this.printer = printer;
		}

		public void Process(Purchase purchase)
		{
			try
			{
				printer.Print(purchase.AsString());
			}
			catch (PrinterOutOfPaperException e)
			{
				Console.WriteLine(e.Message);
				throw new HardwareException("Printer is out of paper.");
			}
		}
	}
}
