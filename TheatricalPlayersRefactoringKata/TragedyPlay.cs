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
                    baseAudienceLimit: 30, 
                    extraPerAudience: 10
                )
            ) 
        { }

        public override double CalculatePrice(int audience)
        {
            double price = base.CalculatePrice(audience);
            
            if (audience > PriceConfig.BaseAudienceLimit)
            {
                int extraAudience = audience - PriceConfig.BaseAudienceLimit;
                price += PriceConfig.ExtraPerAudience * extraAudience;
            }
            return price;
        }
    }
}