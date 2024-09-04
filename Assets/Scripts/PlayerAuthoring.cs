using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    public float MoveSpeed;

    public GameObject BulletPrefab;

    class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity PlayerEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<PlayerTag>(PlayerEntity);
            AddComponent<PlayerMoveInput>(PlayerEntity);

            AddComponent(PlayerEntity, new PlayerMoveSpeed { Value = authoring.MoveSpeed });

            AddComponent<FireProjectileTag>(PlayerEntity);
            SetComponentEnabled<FireProjectileTag>(PlayerEntity, false);

            AddComponent<PlayerBulletPrefab>(PlayerEntity, new PlayerBulletPrefab { Value = GetEntity(authoring.BulletPrefab,TransformUsageFlags.Dynamic) });
        }
    }
}

public struct PlayerMoveInput : IComponentData
{
    public float2 Value;
}
public struct PlayerMoveSpeed : IComponentData
{
    public float Value;
}
public struct PlayerTag : IComponentData
{

}
public struct PlayerBulletPrefab : IComponentData
{
    public Entity Value;
}
public struct ProjectileMoveSpeed : IComponentData
{
    public float Value;
}
public struct FireProjectileTag : IComponentData, IEnableableComponent
{

}