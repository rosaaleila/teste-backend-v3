using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class HistoryPlay : Play
    {
        public HistoryPlay(string title, int lines)
            : base(
                title,
                lines,
                "history",
                new PriceConfiguration(lines)
            ) 
        { }

        public override double CalculatePrice(int audience)
        {
            TragedyPlay equivalentTragedyPlay = new(this.Name, this.Lines);
            ComedyPlay equivalentComedyPlay = new(this.Name, this.Lines);

            double equivalentComedyPrice = equivalentComedyPlay.CalculatePrice(audience);
            double equivalentTragedyPrice = equivalentTragedyPlay.CalculatePrice(audience);

            return equivalentComedyPrice + equivalentTragedyPrice;
        }
    }
}