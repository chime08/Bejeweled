namespace Bejeweled.Core;
// {🔴, 🟣, 🔵, 🟡, 🟢 }
public enum GemType {Red, Yellow, Blue, Purple, Green }
public class Gem
{
    public GemType Type{get;} // match the enum type

    public Gem(GemType type) //constructor
    {
        Type = type;
    }
    public GemType getType()
    {
        return Type;
    }

    public override string ToString() // formatting the gem, taking reference from the Eleven game implementation
    { 
        string t = Type switch
        {
            GemType.Red => "🔴",
            GemType.Purple => "🟣",
            GemType.Blue => "🔵",
            GemType.Yellow => "🟡",
            GemType.Green => "🟢",
            _ => "?"
        };
        return $"{t}";
    }
}