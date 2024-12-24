using System;

namespace TheatricalPlayersRefactoringKata;

public class Play
{
    private const int AudienceToRecieveCredits = 30;
    private string _name;
    private int _lines;
    private string _type;
    private readonly PriceConfiguration _priceConfig;
    public string Name { get => _name; set => _name = value; }
    public string Type { get => _type; set => _type = value; }
    public int Lines
    {
        get { return _lines; }
        set 
        {
            if (value < 1000)
            {
                _lines = 1000;
            }
            else if (value > 4000)
            {
                _lines = 4000;
            }
            else
            {
                _lines = value;
            }
        }
    }

    protected PriceConfiguration PriceConfig => _priceConfig;
    public Play(string name, int lines, string type, PriceConfiguration priceConfig) {
        this._name = name ?? throw new ArgumentNullException(nameof(name));
        this.Lines = lines;
        this._type = type ?? throw new ArgumentNullException(nameof(type));
        this._priceConfig = priceConfig ?? throw new ArgumentNullException(nameof(priceConfig));
    }

    public virtual double CalculatePrice(int audience) => Lines / 10.0;

    public virtual int CalculateCredits(int audience)
    {
        return audience > AudienceToRecieveCredits ? audience - AudienceToRecieveCredits : 0;
    }

}
