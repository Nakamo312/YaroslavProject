using UnityEngine;
//using UnityEngine.InputSystem; // Важно для работы с Input System

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector2 inputVector; 
    public Vector3 moveDirection;
    //public InputActionRefernce actions;
    public CharacterController controller; 

    void Start()
    {
       //(actions, OnMovement);
    }

    //private void EnableAction(InputActionRefernce actions, System.Action<InputAction.CallbackContext> callback)
    //{
        //actions.action.Enable();
       // actions.action.performed += callback;
       // actions.action.canceled += callback;

   // }
    
    //private void OnMovement(InputAction.CallbackContext context)
    //{
        //inputVector = context.ReadValue<Vector2>();

       // Move();
    //}

    void Move()
    {
       moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
       controller.Move(moveDirection * speed);
    }
   
}

