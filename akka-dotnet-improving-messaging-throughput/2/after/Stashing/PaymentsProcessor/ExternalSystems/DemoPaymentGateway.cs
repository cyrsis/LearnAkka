using System;
using System.Threading;

namespace PaymentsProcessor.ExternalSystems
{
    class DemoPaymentGateway : IPaymentGateway
    {
        public void Pay(int accountNumber, decimal amount)
        {
            if (PeakTimeDemoSimulator.IsPeakHours && amount > 100)
            {
                Console.WriteLine(
                    "Account number {0} payment takes longer because is peak & > 100 ", accountNumber);

                Thread.Sleep(2000);
            }
            else
            {
                Thread.Sleep(200);    
            }
            
        }
    }
}
