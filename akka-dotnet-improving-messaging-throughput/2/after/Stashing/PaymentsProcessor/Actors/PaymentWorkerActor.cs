using System;
using Akka.Actor;
using PaymentsProcessor.ExternalSystems;
using PaymentsProcessor.Messages;

namespace PaymentsProcessor.Actors
{
    internal class PaymentWorkerActor : ReceiveActor, IWithUnboundedStash
    {
        private readonly IPaymentGateway _paymentGateway;
        public IStash Stash { get; set; }

        public PaymentWorkerActor(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;

            Receive<SendPaymentMessage>(message => HandleSendPayment(message));
        }

        private void HandleSendPayment(SendPaymentMessage message)
        {
            if (message.Amount > 100 && PeakTimeDemoSimulator.IsPeakHours)
            {
                Console.WriteLine("Stashing payment message for {0} {1}",
                    message.FirstName,
                    message.LastName);

                Stash.Stash();
            }
            else
            {
                Console.WriteLine("Sending payment for {0} {1}", message.FirstName, message.LastName);

                _paymentGateway.Pay(message.AccountNumber, message.Amount);

                Sender.Tell(new PaymentSentMessage(message.AccountNumber));               
            }
        }
    }
}