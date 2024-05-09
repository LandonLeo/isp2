using Blackguard.Utilities;

namespace Blackguard.Tiles;

public class LavaRock : TileDefinition {
    public LavaRock() {
        Name = "LavaRock";
        Glyph = '#';
        Highlight = Highlight.VolcanoStone;
    }
}
