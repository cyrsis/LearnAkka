using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using MovieStreaming.Message;

namespace MovieStreaming.Actor
{
    public class PlaybackActor:ReceiveActor
    {

        public PlaybackActor()
        {
            Console.WriteLine("PlaybackActor is up");


            //Make use of predicate for further down the message being recieve
            //Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message),message=>message is PlayMovieMessage);
            

            
            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));


        }


        //The benefit using Recieve actor, there is no if and else,
        //It automactially call unhandle methods
        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            Console.WriteLine("Recieve Movie Titles {0}",message._movieTitle);
            Console.WriteLine("Recieve user ID {0}", message._userId);

        }


        //This is good for untypeactor but not for recieve actor
        //protected override void OnReceive(object message)
        //{

        //    if (message is PlayMovieMessage)
        //    {
        //        var m = message as PlayMovieMessage;

        //        Console.WriteLine("Recieve Movie titles {0} ",m._movieTitle);
        //        Console.WriteLine("Recieve User Id {0}",m._userId);
        //    }


        //    //if (message is string)
        //    //{
        //    //    Console.WriteLine("Recieve Message : {0}",message);
        //    //}
        //    //else if (message is int)
        //    //{
        //    //    Console.WriteLine("Recieve Messsage : {0}", message);
        //    //}
        //    //else
        //    //{
        //    //    Unhandled(message); //build in message that never reach the type
        //    //}

        //}


        protected override void PreStart()
        {
            base.PreStart();
        }
    }
}
