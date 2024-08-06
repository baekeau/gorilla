using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _moveInput;
    private float speed = 10f;
    
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    } 
    
    private void Update()
    {
        transform.position += new Vector3(_moveInput.x, 0, _moveInput.y) * Time.deltaTime * speed;
    }
}