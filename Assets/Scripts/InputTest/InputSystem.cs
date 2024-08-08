using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

// Assuming your generated input class is named "PlayerInputActions"
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial class InputSystem : SystemBase
{
    private PlayerInputActions playerInput;

    protected override void OnCreate()
    {
        playerInput = new PlayerInputActions();
        playerInput.Enable();
    }

    protected override void OnUpdate()
    {
        var inputEntity = SystemAPI.GetSingletonEntity<InputComponent>();
        var input = SystemAPI.GetComponent<InputComponent>(inputEntity);

        // Read input values
        input.Movement = playerInput.Player.Move.ReadValue<Vector2>();
        input.Jump = playerInput.Player.Jump.WasPressedThisFrame();
        input.Fire = playerInput.Player.Fire.IsPressed();

        // Update the component
        SystemAPI.SetComponent(inputEntity, input);
    }

    protected override void OnDestroy()
    {
        playerInput.Disable();
    }
}