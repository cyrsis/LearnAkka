using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.Core;
using ReactiveStock.ActorModel.Messages;

namespace ReactiveStock.ActorModel.Actors
{
    class StockActor : ReceiveActor
    {
        private readonly string _stockSymbol;
        private decimal _stockPrice;

        private readonly HashSet<IActorRef> _subscribers;

        private readonly IActorRef _priceLookupChild;

        public StockActor(string stockSymbol)
        {
            _stockSymbol = stockSymbol;

            _subscribers = new HashSet<IActorRef>();

            _priceLookupChild = Context.ActorOf(Context.DI().Props<StockPriceLookupActor>());

            Receive<SubscribeToNewStockPricesMessage>(message => _subscribers.Add(message.Subscriber));
            Receive<UnSubscribeFromNewStockPricesMessage>(message => _subscribers.Remove(message.Subscriber));

            Receive<RefreshStockPriceMessage>(message => _priceLookupChild.Tell(message));

            Receive<UpdatedStockPriceMessage>(
                message =>
                {
                    _stockPrice = message.Price;

                    var stockPriceMessage = new StockPriceMessage(_stockSymbol, _stockPrice, message.Date);

                    foreach (var subscriber in _subscribers)
                    {
                        subscriber.Tell(stockPriceMessage);
                    }
                }
                );
        }
    }
}
