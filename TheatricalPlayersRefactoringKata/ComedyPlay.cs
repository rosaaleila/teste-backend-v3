using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class ComedyPlay : Play
    {
        public ComedyPlay(string title, int lines) 
            : base(
                title, 
                lines, 
                "comedy",
                new PriceConfiguration(
                    lines: lines,
                    baseAudienceLimit: 20, 
                    extraPerAudience: 3, 
                    fixedBonus: 100, 
                    additionalPerExtraAudience: 5
                )
            ) 
        { }

        public override double CalculatePrice(int audience)
        {
            double price = PriceConfig.BasePrice;
            price += PriceConfig.ExtraPerAudience * audience;   

            if (audience > PriceConfig.BaseAudienceLimit)
            {
                price += PriceConfig.FixedBonus;
                price += PriceConfig.AdditionalPerExtraAudience * (audience - PriceConfig.BaseAudienceLimit);
            }
            
            return price;
        }

            public override int CalculateCredits(int audience)
            {
                int baseCredits = base.CalculateCredits(audience);
                
                int bonusCredits = audience / 5;
                return baseCredits + bonusCredits;
            }
    }
}