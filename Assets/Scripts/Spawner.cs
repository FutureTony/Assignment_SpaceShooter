
using Unity.Entities;
using Unity.Mathematics;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public float2 SpawnPosition;
    public float spawnRate;
    public float NextSpawnTime;
   
}

