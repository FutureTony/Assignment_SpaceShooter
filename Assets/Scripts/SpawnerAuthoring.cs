using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float spawnRate;

    class SpawnBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new Spawner
            {
                Prefab = GetEntity(authoring.Prefab,TransformUsageFlags.Dynamic),
                SpawnPosition = float2.zero,
                NextSpawnTime = 0,
                spawnRate = authoring.spawnRate
            });
        }

        
    }
}
