using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new TragedyPlay("Hamlet", 4024) },
            { "as-like", new ComedyPlay("As You Like It", 2670) },
            { "othello", new TragedyPlay("Othello", 3560) }
        };

        Invoice invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new("hamlet", 55),
                new("as-like", 35),
                new("othello", 40),
            }
        );

        StatementPrinter statementPrinter = new(plays);
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new TragedyPlay("Hamlet", 4024) },
            { "as-like", new ComedyPlay("As You Like It", 2670) },
            { "othello", new TragedyPlay("Othello", 3560) },
            { "henry-v", new HistoryPlay("Henry V", 3227) },
            { "john", new HistoryPlay("King John", 2648) },
            { "richard-iii", new HistoryPlay("Richard III", 3718) }
        };

        Invoice invoice = new(
            "BigCo",
            new List<Performance>
            {
                new("hamlet", 55),
                new("as-like", 35),
                new("othello", 40),
                new("henry-v", 20),
                new("john", 39),
                new("henry-v", 20)
            }
        );

        StatementPrinter statementPrinter = new(plays);
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXMLStatementExample()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new TragedyPlay("Hamlet", 4024) },
            { "as-like", new ComedyPlay("As You Like It", 2670) },
            { "othello", new TragedyPlay("Othello", 3560) },
            { "henry-v", new HistoryPlay("Henry V", 3227) },
            { "john", new HistoryPlay("King John", 2648) },
            { "richard-iii", new HistoryPlay("Richard III", 3718) }
        };

        Invoice invoice = new(
            "BigCo",
            new List<Performance>
            {
                new("hamlet", 55),
                new("as-like", 35),
                new("othello", 40),
                new("henry-v", 20),
                new("john", 39),
                new("henry-v", 20)
            }
        );

        StatementPrinter statementPrinter = new(plays);
        var result = statementPrinter.ExportToXml(invoice);

        Approvals.Verify(result);
    }
}
