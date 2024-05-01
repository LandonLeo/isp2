using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class Sand : TileDefinition {
    public Sand() {
        Name = "Sand";
        Glyph = '#';
        Highlight = Highlight.Sand;
    }
}
