using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class Snow : TileDefinition {
    public Snow() {
        Name = "Snow";
        Glyph = '#';
        Highlight = Highlight.Snow;
    }
}
