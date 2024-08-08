using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class PlayerSpawnSystem : SystemBase
{
    protected override void OnCreate()
    {
        // Create input entity
        var inputEntity = EntityManager.CreateEntity();
        EntityManager.AddComponentData(inputEntity, new InputComponent());

        // Create player entity
        var playerEntity = EntityManager.CreateEntity();
        EntityManager.AddComponentData(playerEntity, new LocalTransform
        {
            Position = float3.zero,
            Rotation = quaternion.identity,
            Scale = 1f
        });
        EntityManager.AddComponent<PlayerTag>(playerEntity);
        // Add other necessary components...
    }

    protected override void OnUpdate() { }
}