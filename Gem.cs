namespace Bejeweled.Core;
// {🔴, 🟣, 🔵, 🟡, 🟢 }
public enum GemType { Red, Purple, Blue, Yellow, Green }
public class Gem(GemType Type){
    public override string ToString() => Type switch// formatting the gem, taking reference from the Eleven game implementation
    { 
        GemType.Red => "🔴",
        GemType.Purple => "🟣",
        GemType.Blue => "🔵",
        GemType.Yellow => "🟡",
        GemType.Green => "🟢",
        _ => "?"
    };
}