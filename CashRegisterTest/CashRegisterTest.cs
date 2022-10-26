namespace CashRegisterTest
{
	using CashRegister;
	using Moq;
	using System.Reflection;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
			SypPrinter printer = new SypPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.True(printer.HasPrintedV1);
		}

		[Fact]
		public void Should_call_print_when_run_process_given_spy_printer()
		{
			//Given
			var printer = new Mock<Printer>();
			var cashRegister = new CashRegister(printer.Object);
			var purchase = new Purchase();
			// When
			cashRegister.Process(purchase);
			// Then
			printer.Verify(_ => _.Print(It.IsAny<string>()));
        }

		[Fact]
		public void Should_print_purchase_content_when_run_process_given_stub_printer()
		{
			// Given
			var sypPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(sypPrinter.Object);
            var stubPurchase = new Mock<Purchase>();
			stubPurchase.Setup(_ => _.AsString()).Returns("mock content");

			// When
			cashRegister.Process(stubPurchase.Object);

			// Then
			sypPrinter.Verify(_ => _.Print("mock content"));
        }
    }
}
