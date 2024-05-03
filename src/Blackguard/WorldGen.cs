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
                if ((position.X + position.Y) % 2 == 0) {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Snow>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Ice>(), true);
        }
                }else{
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<SnowDark>(), false);
                
                while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<IceDark>(), true);
        }
                
                }
            }
        }
        } else if (rand.NextSingle() < .4) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0) {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<MagicWaste>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<MagicWasteDetail>(), true);
        }
                } else {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<MagicWasteDark>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<MagicWasteDetailDark>(), true);
        }
            }
            }
        }
        } else if (rand.NextSingle() < .6) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0){
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Grass>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Wood>(), true);
        }
                }else{
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<GrassDark>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<WoodDark>(), true);
        }
            }
            }
        }
        } else if (rand.NextSingle() < .8) {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0) {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<Sand>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Cactus>(), true);
        }
                }else {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<SandDark>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<CactusDark>(), true);
        }

            }
            }
        }
        } else {
            for (int i = 0; i < Chunk.CHUNKSIZE; i++) {
            for (int j = 0; j < Chunk.CHUNKSIZE; j++) {
                if ((position.X + position.Y) % 2 == 0) {
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<VolcanoStone>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<Lava>(), true);
        }

                }else
                    ret.Tiles[i, j] = new Tile(Registry.GetDefinition<VolcanoStoneDark>(), false);

                    while (rand.NextSingle() > 0.5) {
            int cx = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);
            int cy = (int)(rand.NextSingle() * Chunk.CHUNKSIZE);

            ret.Tiles[cx, cy] = new Tile(Registry.GetDefinition<LavaDark>(), true);
        }
            }
        }
        
        
        }

        return ret;
    }
}
