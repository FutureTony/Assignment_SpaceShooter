using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


public partial struct SpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {

    }
    public void OnDestroy(ref SystemState state)
    {

    }
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<Spawner> Spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (Spawner.ValueRO.NextSpawnTime <= SystemAPI.Time.ElapsedTime)
            {
                Entity newEntity = state.EntityManager.Instantiate(Spawner.ValueRO.Prefab);
                float3 pos = new float3(Spawner.ValueRO.SpawnPosition.x  + (UnityEngine.Random.Range(-5,5)), Spawner.ValueRO.SpawnPosition.y + (UnityEngine.Random.Range(-5,5)), 0);
                state.EntityManager.SetComponentData(newEntity,LocalTransform.FromPosition(pos));
                Spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + Spawner.ValueRO.NextSpawnTime;
            }
        }
    }
}
