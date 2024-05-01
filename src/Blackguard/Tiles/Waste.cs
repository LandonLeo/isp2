using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class Waste : TileDefinition {
    public Waste() {
        Name = "Waste";
        Glyph = '#';
        Highlight = Highlight.Waste;
    }
}
