using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using MovieStreaming.Actor;
using MovieStreaming.Message;

namespace MovieStreaming
{
    class Program
    {
        static ActorSystem MovieStreamingActorSystem;
        static void Main(string[] args)
        {

            //Creation of the ActorSystem
            MovieStreamingActorSystem = ActorSystem.Create("MovieActorSystem");
            Console.WriteLine("The Actor system is up");


            //Create a new instance of the playbackActors  with use of props instead of "new"
            var playBackActorProps=Props.Create<PlaybackActor>();
                
            var userActorProps = Props.Create<UserActor>();
            //The userActor have to be inherb from the untype actor or recieve actor

            var userActorRef = MovieStreamingActorSystem.ActorOf(userActorProps, "UserActor");


            userActorRef.Tell(new StopMovieMessage());
            //Creat a reference for the PlaybackActor
            var playBackActorRef = MovieStreamingActorSystem.ActorOf(playBackActorProps, "PlayBackActorRef");

            //or it can be a different by Actof

            //MovieStreamingActorSystem.ActorSelection()
            


            //Once I have the reference, we can send messsgae
            playBackActorRef.Tell(new PlayMovieMessage("Akka.net: The movie",12));

            //Can be ask method , only use when necessary
           // playBackActorRef.Ask(new PlayMovieMessage("Akka.net: The movie", 12));

            //Can be Forward method for Rout Messages
            //playBackActorRef.Forward(new PlayMovieMessage("Asska:Net",22));

            //playBackActorRef.Tell(PoisonPill.Instance);

            //Used for testing and send messaage to Actor
            //playBackActorRef.Tell(12);  
            //playBackActorRef.Tell('c');


            


            Console.ReadLine();

            
            //Need to terminate the application
            MovieStreamingActorSystem.Terminate();





        }
    }

    
}
