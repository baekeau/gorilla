using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct RotatingCubeSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RotateSpeed>(); 
    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        RotatingCubeJob rotatingCubeJob = new RotatingCubeJob
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        rotatingCubeJob.ScheduleParallel();
    }

    [BurstCompile]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float deltaTime;
        public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
        {
            float power = 1.0f;
            for (int i = 0; i < 100000; i++)
            {
                power *= 2f;
                power /= 2f;
            }
            localTransform = localTransform.RotateY(rotateSpeed.value * deltaTime * power);
        }
    }
}
