using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 10f;

    private Vector2 rotateStartVector = new Vector2(0, 1);

    private bool isGrounded = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void OnMove(Vector2 input) //this function is being called by the the Unity Events
    {
        //if there is no input, then the velocity is 0
        if (input == Vector2.zero)
        { 
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            return;
        }

        // ROTATION
        float angle = Vector2.SignedAngle(rotateStartVector, input); //this is storing an agle in a variable
        rb.MoveRotation(Quaternion.Euler(0, -angle, 0)); //this is rotating he rb around that angle

        // MOVEMENT
        Vector3 moveDir = transform.forward * moveSpeed; //this is creatin direction that will always be the forwad
        rb.linearVelocity = new Vector3(moveDir.x, rb.linearVelocity.y, moveDir.z); //this is saying, the velocity will be the
    }


    public void OnJump()
    {
        if (!isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

}


