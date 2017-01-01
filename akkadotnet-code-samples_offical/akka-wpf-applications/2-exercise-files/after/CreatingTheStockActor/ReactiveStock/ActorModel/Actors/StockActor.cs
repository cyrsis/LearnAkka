using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using ReactiveStock.ActorModel.Messages;

namespace ReactiveStock.ActorModel.Actors
{
    class StockActor : ReceiveActor
    {
        private readonly string _stockSymbol;

        private readonly HashSet<IActorRef> _subscribers;

        public StockActor(string stockSymbol)
        {
            _stockSymbol = stockSymbol;

            _subscribers = new HashSet<IActorRef>();

            Receive<SubscribeToNewStockPricesMessage>(message => _subscribers.Add(message.Subscriber));
            Receive<UnSubscribeFromNewStockPricesMessage>(message => _subscribers.Remove(message.Subscriber));
        }
    }
}
