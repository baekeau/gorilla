using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class PlayerMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        var inputEntity = SystemAPI.GetSingletonEntity<InputComponent>();
        var input = SystemAPI.GetComponent<InputComponent>(inputEntity);

        Entities
            .WithAll<PlayerTag>() // Assuming you have a PlayerTag component
            .ForEach((ref LocalTransform transform) =>
            {
                // Apply movement
                float3 movement = new float3(input.Movement.x, 0, input.Movement.y);
                transform.Position += movement * 5f * deltaTime; // Adjust speed as needed

                // Handle jump (simplified)
                if (input.Jump)
                {
                    transform.Position += new float3(0, 1, 0); // Simple jump
                }

                // Handle other inputs...
            }).ScheduleParallel();
    }
}