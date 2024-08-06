using Unity.Entities;
using UnityEngine;

public struct RotateSpeed : IComponentData
{
    public float value;
}

public class RotateSpeedAuthoring : MonoBehaviour
{
    public float value;

    private class Baker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateSpeed { value = authoring.value });
        }
    }
    
}
