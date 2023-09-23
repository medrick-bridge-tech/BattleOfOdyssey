using Unity.VisualScripting;
using UnityEngine;

public class InputManager2D : MonoBehaviour
{
    public static bool IsRolling;
    public static bool IsRunning;
    
    public static Vector2 Direction { get; private set; }

    private void Update()
    {
        HandleInput();
    }
        
    private void HandleInput()
    {
        if (CheckWASDPressed())
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else
        {
            Direction = Vector2.zero;
        }

        //Roll
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            IsRolling = true;
        }
        else
        {
            IsRolling = false;
        }

        //Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }
    }

    private bool CheckWASDPressed()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }
}