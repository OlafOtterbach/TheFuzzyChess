using FuzzyChess.Chess;
using FuzzyChess.RunTime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace FuzzyChess
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ModuleChess.Register(serviceCollection);
            var serviceProvider = serviceCollection
                .AddLogging()
                .BuildServiceProvider();

            Output.Init();

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            var game = Game.Create();
            var runTime = serviceProvider.GetService<ChessRunTime>();
            runTime.Run(game);
            logger.LogDebug("Finished");

            Console.ReadKey();
        }
    }
}
