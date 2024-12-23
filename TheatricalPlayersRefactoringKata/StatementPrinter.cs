using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    private readonly Dictionary<string, Play> _plays;

    public StatementPrinter(Dictionary<string, Play> plays)
    {
        _plays = plays ?? throw new ArgumentNullException(nameof(plays));
    }

    public string Print(Invoice invoice)
    {
        if (invoice == null) throw new ArgumentNullException(nameof(invoice));

        double totalAmount = 0.0;
        int volumeCredits = 0;
        var result = new StringBuilder();
        CultureInfo cultureInfo = new("en-US");

        result.AppendLine($"Statement for {invoice.Customer}");

        foreach (var perf in invoice.Performances)
        {
            if (!_plays.TryGetValue(perf.PlayId, out var play))
                throw new KeyNotFoundException($"Play ID '{perf.PlayId}' not found.");

            double price = play.CalculatePrice(perf.Audience);
            int credits = play.CalculateCredits(perf.Audience);

            totalAmount += price;
            volumeCredits += credits;

            result.AppendLine(string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)", play.Name, price, perf.Audience));
        }

        result.AppendLine(string.Format(cultureInfo, "Amount owed is {0:C}", totalAmount));
        result.AppendLine($"You earned {volumeCredits} credits");

        return result.ToString();
    }

    public string ExportToXml(Invoice invoice)
    {
        if (invoice == null) throw new ArgumentNullException(nameof(invoice));

        double totalAmount = 0.0;
        int volumeCredits = 0;
        CultureInfo cultureInfo = new("en-US");

        var statementXml = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Statement",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                new XElement("Customer", invoice.Customer),
                new XElement("Items", invoice.Performances.Select(perf =>
                {
                    if (!_plays.TryGetValue(perf.PlayId, out var play))
                        throw new KeyNotFoundException($"Play ID '{perf.PlayId}' not found.");

                    double price = play.CalculatePrice(perf.Audience);
                    int credits = play.CalculateCredits(perf.Audience);

                    totalAmount += price;
                    volumeCredits += credits;

                    return new XElement("Item",
                        new XElement("AmountOwed", price.ToString("0.##", CultureInfo.InvariantCulture)),
                        new XElement("EarnedCredits", credits),
                        new XElement("Seats", perf.Audience)
                    );
                })),
                new XElement("AmountOwed", totalAmount.ToString("0.##", CultureInfo.InvariantCulture)),
                new XElement("EarnedCredits", volumeCredits)
            )
        );

        return statementXml.Declaration + Environment.NewLine + statementXml.ToString();
    }

}
