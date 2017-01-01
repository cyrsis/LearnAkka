using System;
using Akka.Actor;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem _MovieStreamingActorSystem;
        //private static ActorSystem _MovieStreamingActorSystem;
    //    private static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            //MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            _MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            //_MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            Console.ReadLine();

            _MovieStreamingActorSystem.Shutdown();
        }
    }
}
