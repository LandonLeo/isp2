using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class Lava : TileDefinition {
    public Lava() {
        Name = "Lava";
        Glyph = '@';
        Highlight = Highlight.Lava;
    }
}
