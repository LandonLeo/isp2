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
        for (int k = 0; k < 10; k++) {
        Chunk ret = new(position);

        // TODO: Actual noise-based worldgen
        if (rand.NextSingle() < .2) {
        for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Snow>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Snow2>(), false);
            }
        }
        } else if (rand.NextSingle() < .4) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Waste>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Waste2>(), false);
            }
        }
        } else if (rand.NextSingle() < .6) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Grass>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Grass2>(), false);
            }
        }
        } else if (rand.NextSingle() < .8) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Sand>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Sand2>(), false);
            }
        }
        } else {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0)
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Lava>(), false);
                else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Lava2>(), false);
            }
        }
        }

        while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Stone>(), true);
        }

        return ret;
    }
#pragma warning restore CS0162 // Unreachable code detected
    }
}
