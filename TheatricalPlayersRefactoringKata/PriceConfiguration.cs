using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class PriceConfiguration
    {
        public double ExtraPerAudience { get; set; } = 0;
        public double BaseAudienceLimit { get; set; } = 0;
        public double FixedBonus { get; set; } = 0; 
        public double AdditionalPerExtraAudience { get; set; } = 0;
        public PriceConfiguration(
            double fixedBonus = 0, 
            double extraPerAudience = 0, 
            int baseAudienceLimit = 0, 
            double additionalPerExtraAudience = 0
        )
        {
            FixedBonus = fixedBonus;
            ExtraPerAudience = extraPerAudience;
            BaseAudienceLimit = baseAudienceLimit;
            AdditionalPerExtraAudience = additionalPerExtraAudience;
        }
    }

}