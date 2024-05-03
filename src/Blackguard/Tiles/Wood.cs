using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class Wood : TileDefinition {
    public Wood() {
        Name = "Wood";
        Glyph = '#';
        Highlight = Highlight.Wood;
    }
}
