// using Unity.Entities;
// using UnityEngine;
// using UnityEngine.InputSystem;
//
// [UpdateInGroup(typeof(InitializationSystemGroup))]
// public partial class InputSystem : SystemBase
// {
//     private GameInput _gameInput;
//
//     protected override void OnCreate()
//     {
//         _gameInput = new GameInput();
//         _gameInput.Gameplay.Enable();
//         
//         // Set up callbacks
//         _gameInput.Gameplay.Move.performed += OnMove;
//         _gameInput.Gameplay.Pause.performed += OnPause;
//         _gameInput.UI.Resume.performed += OnResume;
//     }
//
//     protected override void OnDestroy()
//     {
//         _gameInput.Gameplay.Move.performed -= OnMove;
//         _gameInput.Gameplay.Pause.performed -= OnPause;
//         _gameInput.UI.Resume.performed -= OnResume;
//         _gameInput.Dispose();
//     }
//
//     private void OnMove(InputAction.CallbackContext context)
//     {
//         var moveInput = context.ReadValue<Vector2>();
//         EntityManager.CreateEntity(typeof(InputMoveComponent));
//         EntityManager.SetComponentData(EntityManager.CreateEntity(), new InputMoveComponent { MoveInput = moveInput });
//     }
//
//     private void OnPause(InputAction.CallbackContext context)
//     {
//         _gameInput.Gameplay.Disable();
//         _gameInput.UI.Enable();
//         EntityManager.CreateEntity(typeof(InputUIComponent));
//         EntityManager.SetComponentData(EntityManager.CreateEntity(), new InputUIComponent { IsPaused = true });
//     }
//
//     private void OnResume(InputAction.CallbackContext context)
//     {
//         _gameInput.UI.Disable();
//         _gameInput.Gameplay.Enable();
//         EntityManager.CreateEntity(typeof(InputUIComponent));
//         EntityManager.SetComponentData(EntityManager.CreateEntity(), new InputUIComponent { IsPaused = false });
//     }
//
//     protected override void OnUpdate()
//     {
//         // This system doesn't need an OnUpdate method, as it's event-driven
//     }
// }