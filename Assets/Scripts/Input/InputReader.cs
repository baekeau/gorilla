using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IUIActions
{
    private GameInput _gameInput;

    private void OnEnable()
    {
        Debug.Log("OnEnable called");
        if (_gameInput == null)
        {
            _gameInput = new GameInput(); 
            _gameInput.Gameplay.SetCallbacks(this); 
            _gameInput.UI.SetCallbacks(this);
            
            Debug.Log("Setting GamePlay");
            SetGamePlay();
        }
        
    }

    public void SetGamePlay()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.UI.Disable();
    }
    
    public void SetUI()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.UI.Enable();
    }
    
    public event Action<Vector2> MoveEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log($"Phase: {context.phase}, Value: {context.ReadValue<Vector2>()}");
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        SetUI();
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        SetGamePlay();
    }
}
