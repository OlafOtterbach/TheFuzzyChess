using FuzzyChess.Mathmatics;
using FuzzyChess.RunTime.Evaluation;
using System;
using static FuzzyChess.Mathmatics.STMNT;
using static FuzzyChess.ChessRuleSetDefinitions.ChessGameEvaluations;

namespace FuzzyChess.ChessRuleSetDefinitions
{
    public class ChessRuleSet : RuleSet
    {
        public Func<ChessContext, double>
        Rating_Angriff
            => Rate(5000).For(Zielfeld_von_Gegner_Besetz.And(Besetzender_Gegner_Ist_Hoeher));

        public Func<ChessContext, double>
        Rating_Angriff2
            => Rate(1000).For(Zielfeld_von_Gegner_Besetz.And(Not(Zielfeld_ist_bedroht)));

        public Func<ChessContext, double>
        Rating_Angriff3
            => Rate(1000).For(Zielfeld_von_Gegner_Besetz.And(Zielfeld_ist_bedroht).And(Zielfeld_ist_gedeckt).And(Bedrohender_Gegner_ist_hoeher_oder_gleich));

        public Func<ChessContext, double>
        Eigenes_Zielfeld_bedroht_und_Zielfeld_ist_nicht_bedroht
            => Rate(1000).For(Eigenes_Feld_ist_bedroht.And((Not(Zielfeld_ist_bedroht))));

        public Func<ChessContext, double>
        Eigenes_Zielfeld_bedroht_Zielfeld_ist_bedroht_
            => Rate(1000).For(Eigenes_Feld_ist_bedroht.And(Zielfeld_ist_bedroht).And(Zielfeld_ist_gedeckt).And(Bedrohender_Gegner_ist_hoeher_oder_gleich));

        public Func<ChessContext, double>
        Rating_Zielfeld_leer_und_nicht_bedroht
            => Rate(100).For(Zielfeld_ist_leer.And(Not(Zielfeld_ist_bedroht)));

        public Func<ChessContext, double>
        Rating_Zielfeld_leer_und_bedroht_und_nicht_gedeckt
            => Rate(-1000).For(Zielfeld_ist_leer.And(Zielfeld_ist_bedroht).And(Not(Zielfeld_ist_gedeckt)));

        public Func<ChessContext, double>
        Rating_Zielfeld_leer_und_bedroht_und_Gegner_niedriger
            => Rate(-1000).For(Zielfeld_ist_leer.And(Zielfeld_ist_bedroht).And(Bedrohender_Gegner_ist_niedriger));

        public Func<ChessContext, double>
        Rating_Zug_springt_zurück
            => Rate(-1100).For(Zug_springt_zurück);

        public Func<ChessContext, double>
        Rating_Figur_hat_erst_gezogen
            => Rate(-1100).For(Figur_hat_erst_gezogen);
    }
}