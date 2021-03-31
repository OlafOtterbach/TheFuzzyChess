using FuzzyChess.ChessRuleSetDefinitions;
using FuzzyChess.RunTime;
using FuzzyChess.RunTime.Evaluation;
using FuzzyChess.RunTime.Moving;
using Microsoft.Extensions.DependencyInjection;

namespace FuzzyChess
{
    public static class ModuleChess
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IMoveGenerator, MoveGenerator>();
            services.AddSingleton<IRuleSet, ChessRuleSet>();
            services.AddSingleton<IEvaluator, Evaluator>();
            services.AddSingleton<ChessRunTime>();
        }
    }
}
