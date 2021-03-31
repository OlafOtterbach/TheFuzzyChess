namespace FuzzyChess.RunTime.Evaluation
{
    public interface IRuleSet
    {
        double EvaluateMove(ChessContext ctx);
    }

}
