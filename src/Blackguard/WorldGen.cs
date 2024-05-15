using System;
using System.Security.Cryptography.X509Certificates;
using Blackguard.Tiles;
using Blackguard.Utilities;

namespace Blackguard;

public class WorldGen {
    private readonly Random rand;

    public WorldGen(int seed) {
        rand = new(seed);
    }

    public Chunk GenChunk(Point position, int change) {
        
        Chunk ret = new(position);

        // TODO: Actual noise-based worldgen
        if (change <= 2) {
        for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Snow>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<SnowDark>(), false);
            }
        }
        } else if (change <= 4) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<MagicWaste>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<MagicWasteDark>(), false);
            }
        }
        } else if (change <= 6) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Grass>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<GrassDark>(), false);
            }
        }
        } else if (change <= 8) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Sand>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<SandDark>(), false);
            }
        }
        } else {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0) {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<LavaRock>(), false);

                }else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<LavaRockDark>(), false);
            }
        }
        }

            while (rand.NextSingle() > 0.5) {
                int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
                int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

                if ((position.X + position.Y) % 2 == 0) {
                    if (change < .2) {
                    ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Ice>(), true);
                    } else if (change < .4) {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<MagicWasteDetail>(), true);

                    } else if (change < .6) {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Wood>(), true);

                    } else if (change < .8) {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Cactus>(), true);

                    } else {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Lava>(), true);
                    }

                }else {
                   if (change < .2) {
                    ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<IceDark>(), true);
                    } else if (change < .4) {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<MagicWasteDetailDark>(), true);

                    } else if (change < .6) {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<WoodDark>(), true);

                    } else if (change < .8) {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<CactusDark>(), true);

                    } else {
                        ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<LavaDark>(), true);
                    }
            }
            }
        return ret;
    }
}
