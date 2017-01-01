using System;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using PaymentsProcessor.Actors;
using PaymentsProcessor.ExternalSystems;
using PaymentsProcessor.Messages;

namespace PaymentsProcessor
{
    class Program
    {
        private static ActorSystem ActorSystem;

        static void Main(string[] args)
        {
            CreateActorSystem();

            IActorRef jobCoordinator= ActorSystem.ActorOf<JobCoordinatorActor>("JobCoordinator");
            
            PeakTimeDemoSimulator.StartDemo(stayPeakTimeForSeconds: 6);

            jobCoordinator.Tell(new ProcessFileMessage("file1.csv"));

            ActorSystem.AwaitTermination();

            Console.WriteLine("Job complete");
            Console.ReadLine();
        }

        private static void CreateActorSystem()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DemoPaymentGateway>().As<IPaymentGateway>();
            builder.RegisterType<PaymentWorkerActor>();
            var container = builder.Build();

            ActorSystem = ActorSystem.Create("PaymentProcessing");

            IDependencyResolver resolver = new AutoFacDependencyResolver(container, ActorSystem);
        }
    }
}
