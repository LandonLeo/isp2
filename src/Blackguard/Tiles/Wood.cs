using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class Wood : TileDefinition {
    public Wood() {
        Name = "Wood";
        Glyph = 'Y';
        Highlight = Highlight.Wood;
    }
}
