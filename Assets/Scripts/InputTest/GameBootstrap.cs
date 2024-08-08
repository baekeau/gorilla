using Unity.Entities;

public partial class GameBootstrap : SystemBase
{
    protected override void OnCreate()
    {
        // Add systems to the default world
        World.GetOrCreateSystemManaged<InputSystem>();
        World.GetOrCreateSystemManaged<PlayerSpawnSystem>();
        World.GetOrCreateSystemManaged<PlayerMovementSystem>();
    }

    protected override void OnUpdate() { }
}