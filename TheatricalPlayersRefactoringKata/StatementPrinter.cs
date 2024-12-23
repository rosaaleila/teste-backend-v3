using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        double totalAmount = 0.0;
        int volumeCredits = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new("en-US");

        foreach(var perf in invoice.Performances) 
        {
            var play = plays[perf.PlayId];

            var lines = play.Lines;
            double price;
            int credits;
            
            switch (play.Type) 
            {
                case "tragedy":
                    TragedyPlay tragedyPlay = new(play.Name, lines);

                    price = tragedyPlay.CalculatePrice(perf.Audience);
                    credits = tragedyPlay.CalculateCredits(perf.Audience);

                    break;
                case "comedy":
                    ComedyPlay comedyPlay = new(play.Name, lines);
                    
                    price = comedyPlay.CalculatePrice(perf.Audience);
                    credits = comedyPlay.CalculateCredits(perf.Audience);

                    break;
                case "history":
                    HistoryPlay historyPlay = new(play.Name, lines);

                    price = historyPlay.CalculatePrice(perf.Audience);
                    credits = historyPlay.CalculateCredits(perf.Audience);

                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }

            totalAmount += price;
            volumeCredits += credits;

            result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, price, perf.Audience);
        }
        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", totalAmount);
        result += String.Format("You earned {0} credits\n", volumeCredits);
        return result;
    }

}
