using System;
using System.Linq;
using Akka.Actor;
using MovieStreaming.Message;

namespace MovieStreaming
{

    public class StopMovieMessage
    {
        private object _currentlyWatching;

        public StopMovieMessage()
        {
            Console.WriteLine("Creating a userActor");
            Receive<PlayMovieMessage>(message => HandleMovieMessage(message));
            Receive<StopMovieMessage>(message => HandleMovieMessage(message));
        }

        private void HandleMovieMessage(PlayMovieMessage message)
        {
            if (_currentlyWatching!=null)
            {
                
            }
        }
    }
}
