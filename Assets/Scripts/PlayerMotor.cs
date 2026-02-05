using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMotor : MonoBehaviour
{
    private InputSystem_Actions m_actions; // a class I generated through the input system so i can access it

    private Rigidbody rb;

    private Vector2 m_moveAmt; //variable to store inputs -> move forward/backward & left/right 

    public float moveSpeed = 5f;
    public float flySpeed = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        m_actions = new InputSystem_Actions();
    }

    private void FixedUpdate()
    {
                           //where the dragon is facing       //dragon's right side          --> they are combined with input: forward/backward/left/right
        Vector3 direction = transform.forward * m_moveAmt.y + transform.right * m_moveAmt.x;
        rb.linearVelocity = direction * moveSpeed; //move the dragon in that specofoc direction * specfic speed
    }

    public void OnMove(InputAction.CallbackContext context) //this function is being called by the the Unity Events
    {
        m_moveAmt = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) //this function is being called by the the Unity Events
    {
        Vector2 inputValues = context.ReadValue<Vector2>();

        Rotate(inputValues.x);
        Rotate(inputValues.y);
    }

    public void Rotate(float inputX) //just the left or right of the mouse
    {
        Vector3 mouseDirection = new Vector3(0, inputX , 0 );
        transform.Rotate(mouseDirection * Time.deltaTime * flySpeed);
    }

}
