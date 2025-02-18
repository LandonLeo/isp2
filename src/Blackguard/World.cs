using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Blackguard.Entities;
using Blackguard.Tiles;
using Blackguard.UI;
using Blackguard.Utilities;
using Mindmagma.Curses;
using Newtonsoft.Json;

using SpawnCondition = System.Func<Blackguard.Game, bool>;

namespace Blackguard;

[JsonObject(MemberSerialization.OptIn)]
public class World {
    [JsonProperty]
    public string Name { get; private set; }

    [JsonProperty]
    public DateTime CreationDate { get; private set; }

    [JsonProperty]
    public TimeSpan Playtime { get; private set; }

    [JsonProperty]
    public int Seed { get; private set; }

    private WorldGen gen = null!;
    public string BaseSavePath => Path.Combine(Game.WorldsPath, Name);
    public string MetaSavePath => Path.Combine(BaseSavePath, "meta");
    public string ChunksPath => Path.Combine(BaseSavePath, "Chunks");

    public Dictionary<Point, Chunk> ChunksByPosition;
    public Point simulationDistance; // Number of chunks to simulate on all four sides of the player

    private List<(EntityDefinition, SpawnCondition)> spawnConditions = null!;
    private List<(Chunk, Entity)> entitiesToMove = null!;

    public World(string name) {
        Name = name;
        CreationDate = DateTime.Now;
        Playtime = TimeSpan.Zero;
        ChunksByPosition = new();
    }

    public static World CreateNew(Game state, string name) {
        World world = new(name) {
            Seed = (int)DateTime.Now.Ticks // I sure hope this doesn't truncate
        };
        world.Serialize();
        world.Initialize(state);

        return world;
    }

    private void LoadChunks(Point center) {
        for (int i = -simulationDistance.X; i <= simulationDistance.X; i++) {
            for (int j = -simulationDistance.Y; j <= simulationDistance.Y; j++) {
                Point position = new(center.X + i, center.Y + j);
                Point position1 = new(center.X + i + 1, center.Y + j);
                Point position2 = new(center.X + i, center.Y + j + 1);
                Point position3 = new(center.X + i - 1, center.Y + j);
                Point position4 = new(center.X + i, center.Y + j - 1);
                Point position5 = new(center.X + i + 1, center.Y + j + 1);
                Point position6 = new(center.X + i - 1, center.Y + j + 1);
                Point position7 = new(center.X + i - 1, center.Y + j - 1);
                Point position8 = new(center.X + i + 1, center.Y + j - 1);
                Point position9 = new(center.X + i + 2, center.Y + j);
                Point position10 = new(center.X + i, center.Y + j + 2);
                Point position11 = new(center.X + i - 2, center.Y + j);
                Point position12 = new(center.X + i, center.Y + j - 2);
                Point position13 = new(center.X + i + 2, center.Y + j + 1);
                Point position14 = new(center.X + i - 2, center.Y + j + 1);
                Point position15 = new(center.X + i - 2, center.Y + j - 1);
                Point position16 = new(center.X + i + 2, center.Y + j - 1);
                Point position17 = new(center.X + i + 1, center.Y + j + 2);
                Point position18 = new(center.X + i - 1, center.Y + j + 2);
                Point position19 = new(center.X + i - 1, center.Y + j - 2);
                Point position20 = new(center.X + i + 1, center.Y + j - 2);
                

                if (!ChunksByPosition.ContainsKey(position)) {
                if (RandomNumberGenerator.GetInt32(11) < 2) {
                    int biome = RandomNumberGenerator.GetInt32(11);
                    ChunksByPosition.Add(position, Chunk.Deserialize(ChunksPath, position) ?? gen.GenChunk(position, biome));
                    if (!ChunksByPosition.ContainsKey(position1))
                    ChunksByPosition.Add(position1, Chunk.Deserialize(ChunksPath, position1) ?? gen.GenChunk(position1, biome));
                    if (!ChunksByPosition.ContainsKey(position2))
                    ChunksByPosition.Add(position2, Chunk.Deserialize(ChunksPath, position2) ?? gen.GenChunk(position2, biome));
                    if (!ChunksByPosition.ContainsKey(position3))
                    ChunksByPosition.Add(position3, Chunk.Deserialize(ChunksPath, position3) ?? gen.GenChunk(position3, biome));
                    if (!ChunksByPosition.ContainsKey(position4))
                    ChunksByPosition.Add(position4, Chunk.Deserialize(ChunksPath, position4) ?? gen.GenChunk(position4, biome));
                    if (!ChunksByPosition.ContainsKey(position5))
                    ChunksByPosition.Add(position5, Chunk.Deserialize(ChunksPath, position5) ?? gen.GenChunk(position5, biome));
                    if (!ChunksByPosition.ContainsKey(position6))
                    ChunksByPosition.Add(position6, Chunk.Deserialize(ChunksPath, position6) ?? gen.GenChunk(position6, biome));
                    if (!ChunksByPosition.ContainsKey(position7))
                    ChunksByPosition.Add(position7, Chunk.Deserialize(ChunksPath, position7) ?? gen.GenChunk(position7, biome));
                    if (!ChunksByPosition.ContainsKey(position8))
                    ChunksByPosition.Add(position8, Chunk.Deserialize(ChunksPath, position8) ?? gen.GenChunk(position8, biome));
                    if (!ChunksByPosition.ContainsKey(position9))
                    ChunksByPosition.Add(position9, Chunk.Deserialize(ChunksPath, position9) ?? gen.GenChunk(position9, biome));
                    if (!ChunksByPosition.ContainsKey(position10))
                    ChunksByPosition.Add(position10, Chunk.Deserialize(ChunksPath, position10) ?? gen.GenChunk(position10, biome));
                    if (!ChunksByPosition.ContainsKey(position11))
                    ChunksByPosition.Add(position11, Chunk.Deserialize(ChunksPath, position11) ?? gen.GenChunk(position11, biome));
                    if (!ChunksByPosition.ContainsKey(position12))
                    ChunksByPosition.Add(position12, Chunk.Deserialize(ChunksPath, position12) ?? gen.GenChunk(position12, biome));
                    if (!ChunksByPosition.ContainsKey(position13))
                    ChunksByPosition.Add(position13, Chunk.Deserialize(ChunksPath, position13) ?? gen.GenChunk(position13, biome));
                    if (!ChunksByPosition.ContainsKey(position14))
                    ChunksByPosition.Add(position14, Chunk.Deserialize(ChunksPath, position14) ?? gen.GenChunk(position14, biome));
                    if (!ChunksByPosition.ContainsKey(position15))
                    ChunksByPosition.Add(position15, Chunk.Deserialize(ChunksPath, position15) ?? gen.GenChunk(position15, biome));
                    if (!ChunksByPosition.ContainsKey(position16))
                    ChunksByPosition.Add(position16, Chunk.Deserialize(ChunksPath, position16) ?? gen.GenChunk(position16, biome));
                    if (!ChunksByPosition.ContainsKey(position17))
                    ChunksByPosition.Add(position17, Chunk.Deserialize(ChunksPath, position17) ?? gen.GenChunk(position17, biome));
                    if (!ChunksByPosition.ContainsKey(position18))
                    ChunksByPosition.Add(position18, Chunk.Deserialize(ChunksPath, position18) ?? gen.GenChunk(position18, biome));
                    if (!ChunksByPosition.ContainsKey(position19))
                    ChunksByPosition.Add(position19, Chunk.Deserialize(ChunksPath, position19) ?? gen.GenChunk(position19, biome));
                    if (!ChunksByPosition.ContainsKey(position20))
                    ChunksByPosition.Add(position20, Chunk.Deserialize(ChunksPath, position20) ?? gen.GenChunk(position20, biome));
                }else {
                    ChunksByPosition.Add(position, Chunk.Deserialize(ChunksPath, position) ?? gen.GenChunk(position, 5));
                    }
                }   
            }
        }
    }

    public void Initialize(Game state) {
        gen = new WorldGen(Seed);
        spawnConditions = new List<(EntityDefinition, SpawnCondition)>();
        entitiesToMove = new();

        foreach ((Type _, Registry.Definition def) in Registry.GetRegistry<EntityDefinition>().defsByType) {
            EntityDefinition eDef = (EntityDefinition)def;

            if (eDef.SpawnConditions != null) {
                foreach (SpawnCondition c in eDef.SpawnConditions)
                    spawnConditions.Add(item: (eDef, c));
            }
        }

        HandleTermResize();

        LoadChunks(state.Player.ChunkPosition);
    }

    public void RunTick(Game state) {
        // Remove faraway chunks
        foreach ((Point position, Chunk chunk) in ChunksByPosition) {
            if (Math.Abs(position.X - state.Player.ChunkPosition.X) > simulationDistance.X || Math.Abs(position.Y - state.Player.ChunkPosition.Y) > simulationDistance.Y) {
                ChunksByPosition.Remove(key: position);
                chunk.Serialize(ChunksPath);
                state.Player.nearbyEntities -= chunk.Entities.Count;
            }
        }

        LoadChunks(state.Player.ChunkPosition);

        int netLoadedEntities = 0;

        entitiesToMove.Clear();
        foreach ((_, Chunk chunk) in ChunksByPosition) {
            Span<Entity> entitiesSpan = CollectionsMarshal.AsSpan(chunk.Entities);
            for (int i = 0; i < entitiesSpan.Length; i++) {
                ref Entity e = ref entitiesSpan[i];

                Point oldpos = e.ChunkPosition;
                e.Type.AI(state, ref e);

                // Entity has moved into a different chunk
                if (oldpos != e.ChunkPosition)
                    entitiesToMove.Add(item: (chunk, e));
            }
        }

        // Prevents entities from being updated twice if they move into a chunk that will be updated later.
        foreach ((Chunk c, Entity e) in entitiesToMove) {
            if (ChunksByPosition.TryGetValue(e.ChunkPosition, out Chunk? newChunk)) {
                newChunk.Entities.Add(e);
                netLoadedEntities++;
            }

            c.Entities.Remove(e);
            netLoadedEntities--;
        }

        netLoadedEntities += SpawnEntitiesInWorld(state);

        state.Player.nearbyEntities += netLoadedEntities;
    }

    private readonly List<Chunk> chunksWithEntities = new();
    public void Render(Drawable drawable, Game state, int maxw, int maxh) {
        chunksWithEntities.Clear();

        foreach ((_, Chunk chunk) in ChunksByPosition) {
            Point sp = Utils.ToScreenPos(state.ViewOrigin, chunk.WorldPosition);
            if (!Utils.CheckOutOfBounds(sp.X, sp.Y, Chunk.CHUNKSIZE, Chunk.CHUNKSIZE, maxw, maxh, out int byX, out int byY))
                chunk.Render(drawable, sp.X, sp.Y, 0, 0, state.drawChunkOutline);
            else if (Math.Abs(byX) < Chunk.CHUNKSIZE && Math.Abs(byY) < Chunk.CHUNKSIZE)
                chunk.Render(drawable, sp.X, sp.Y, byX, byY, state.drawChunkOutline);

            if (chunk.EntitesToRender)
                chunksWithEntities.Add(chunk);
        }

        // Render entities after rendering chunks to avoid entities being painted over by tiles
        foreach (Chunk chunk in chunksWithEntities) {
            for (int i = 0; i < chunk.Entities.Count; i++) {
                Entity e = chunk.Entities[i];

                Point sp = Utils.ToScreenPos(state.ViewOrigin, (Point)e.Position);
                if (!Utils.CheckOutOfBounds(sp.X, sp.Y, e.Type.Width, e.Type.Height, maxw, maxh, out int byX, out int byY))
                    e.Type.Render(ref e, drawable, sp.X, sp.Y, 0, 0);
                else if (Math.Abs(byX) < e.Type.Width && Math.Abs(byY) < e.Type.Height)
                    e.Type.Render(ref e, drawable, sp.X, sp.Y, byX, byY);
            }
        }
    }

    public Tile? GetTile(Point position) {
        Point chunkPosition = position.ToChunkPosition();

        if (!ChunksByPosition.TryGetValue(chunkPosition, out Chunk? value))
            return null;

        return value.Tiles[position.X - value.Position.X * Chunk.CHUNKSIZE, position.Y - value.Position.Y * Chunk.CHUNKSIZE];
    }

    public void Serialize() {
        Directory.CreateDirectory(BaseSavePath);
        Directory.CreateDirectory(ChunksPath);

        string json = JsonConvert.SerializeObject(this);

        File.WriteAllText(MetaSavePath, json);

        foreach ((_, Chunk chunk) in ChunksByPosition)
            chunk.Serialize(ChunksPath);
    }

    public static World? Deserialize(string path) {
        string json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<World>(json);
    }

    public void Delete() {
        Directory.Delete(BaseSavePath, true);
    }

    public void HandleTermResize() {
        simulationDistance.X = NCurses.Columns / Chunk.CHUNKSIZE;
        simulationDistance.Y = NCurses.Lines / Chunk.CHUNKSIZE;
    }

    // This isn't uniform. I couldn't find how to make it uniform
    private Point RandPosOffscreen(Game state) {
        int side = Game.Rand.Next(3);

        // Offsets from the player's position
        int offX = 0;
        int offY = 0;

        // All of these undershoot their maximums by somewhere between 0 and 1 chunk. Oh well
        switch (side) {
            case 0: // Left
                offX = Game.Rand.Next(-simulationDistance.X * Chunk.CHUNKSIZE, -NCurses.Columns / 2);
                offY = Game.Rand.Next(-simulationDistance.Y, simulationDistance.Y);
                break;
            case 1: // Top
                offX = Game.Rand.Next(-NCurses.Columns / 2, NCurses.Columns / 2);
                offY = Game.Rand.Next(NCurses.Lines / 2, simulationDistance.Y * Chunk.CHUNKSIZE);
                break;
            case 2: // Right
                offX = Game.Rand.Next(NCurses.Columns / 2, simulationDistance.X * Chunk.CHUNKSIZE);
                offY = Game.Rand.Next(-simulationDistance.Y, simulationDistance.Y);
                break;
            case 3: // Bottom
                offX = Game.Rand.Next(-NCurses.Columns / 2, NCurses.Columns / 2);
                offY = Game.Rand.Next(-NCurses.Lines / 2, -simulationDistance.Y * Chunk.CHUNKSIZE);
                break;
        }

        return new((int)state.Player.Position.X + offX, (int)state.Player.Position.Y + offY);
    }

    public int SpawnEntitiesInWorld(Game state) {
        int numSpawned = 0;
        float spawnChance = 1 / 50f; // Chance for an entity to spawn any given tick
        int maxSpawns = 5;

        if (state.Player.nearbyEntities < maxSpawns && Game.Rand.NextSingle() < spawnChance) {
            foreach ((EntityDefinition eDef, SpawnCondition condition) in spawnConditions) {
                if (condition(state)) {
                    Point pos = RandPosOffscreen(state);
                    ChunksByPosition[pos.ToChunkPosition()].Entities.Add(new(eDef, (Vector2)pos));
                    numSpawned++;
                }
            }
        }

        return numSpawned;
    }
}
