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

    public Chunk GenChunk(Point position) {
        Chunk ret = new(position);

        // TODO: Actual noise-based worldgen
        if (rand.NextSingle() < .2) {
        for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Snow>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<SnowDark>(), false);
            }
        }
        } else if (rand.NextSingle() < .4) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<MagicWaste>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<MagicWasteDark>(), false);
            }
        }
        } else if (rand.NextSingle() < .6) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Grass>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<GrassDark>(), false);
            }
        }
        } else if (rand.NextSingle() < .8) {
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
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<VolcanoStone>(), false);

                }else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<VolcanoStoneDark>(), false);
            }
        }
        
        
        }

        return ret;
    }
}
