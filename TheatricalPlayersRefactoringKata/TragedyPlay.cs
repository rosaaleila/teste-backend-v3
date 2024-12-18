using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class TragedyPlay: Play
    {
        public TragedyPlay(string title, int lines) 
            : base(
                title,
                lines,
                "tragedy",
                new PriceConfiguration(
                    lines: lines,
                    baseAudienceLimit: 30, 
                    extraPerAudience: 10
                )
            ) 
        { }

        public override double CalculatePrice(int audience)
        {
            double price = PriceConfig.BasePrice;
            if (audience > PriceConfig.BaseAudienceLimit)
            {
                price += PriceConfig.ExtraPerAudience * (audience - PriceConfig.BaseAudienceLimit);
            }
            return price;
        }
    }
}