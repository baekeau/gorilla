using Unity.Entities;
using UnityEngine;

    public struct InputMoveComponent : IComponentData
    {
        public Vector2 MoveInput;

    }
    
    public struct InputUIComponent : IComponentData
    {
        public bool isPaused;
    }