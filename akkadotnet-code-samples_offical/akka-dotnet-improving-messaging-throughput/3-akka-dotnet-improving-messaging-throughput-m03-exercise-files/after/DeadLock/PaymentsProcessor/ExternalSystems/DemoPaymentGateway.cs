using System;
using System.Threading.Tasks;

namespace PaymentsProcessor.ExternalSystems
{
    class DemoPaymentGateway : IPaymentGateway
    {
        public async Task<PaymentReceipt> Pay(int accountNumber, decimal amount)
        {
            return await Task.Delay(int.MaxValue)
                .ContinueWith<PaymentReceipt>(
                    task =>
                    {
                        return new PaymentReceipt()
                               {
                                   AccountNumber = accountNumber,
                                   PaymentConfirmationReceipt = Guid.NewGuid().ToString()
                               };
                    });
        }
    }
}
