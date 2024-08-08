using Unity.Entities;
using Unity.Mathematics;

public struct InputComponent : IComponentData
{
    public float2 Movement;
    public bool Jump;
    public bool Fire;
    
}