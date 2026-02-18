using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] Animator animator;
    //[SerializeField] Transform dragon; //

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    private Vector2 rotateStartVector = new Vector2(0, 1);
    private bool isGrounded = false;

    [SerializeField] private float fallForce = 0.01f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //dragon = GetComponent<Transform>(); // 
    }


    public void OnMove(Vector2 input) //this function is being called by the the Unity Events
    {
        //if there is no input, then the velocity is 0
        if (input == Vector2.zero)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            animator.SetBool("IsWalking", false);

            return;
        }


        animator.SetBool("IsWalking", true);

        // ROTATION
        float angle = Vector2.SignedAngle(rotateStartVector, input); //this is storing an agle in a variable
        rb.MoveRotation(Quaternion.Euler(0, -angle, 0)); //this is rotating he rb around that angle

        // MOVEMENT
        Vector3 moveDir = transform.forward * moveSpeed; //this is creatin direction that will always be the forwad
        rb.linearVelocity = new Vector3(moveDir.x, rb.linearVelocity.y, moveDir.z); //this is saying, the velocity will be the
    }


    public void OnJump()
    {

        if (!isGrounded)
        {
            return;
        }
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetBool("IsJumping", true);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsGlinding", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    public void OnGlind(bool glideHeld)
    {
        if (!isGrounded && glideHeld)
        {
            animator.SetBool("IsGlinding", true);

            rb.useGravity = false; // turn off normal gravity
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -fallForce, rb.linearVelocity.z); // constant slow fall;
        }
        else
        {
            rb.useGravity = true;
            animator.SetBool("IsGlinding", false);
        }

    }
        /*public void OnGlind(bool glideHeld)
        {
            if (!isGrounded && glideHeld)
            {
                animator.SetBool("IsGlinding", true);

                fallForce += fallForce * Time.deltaTime;
                rb.AddForce(Vector3.down  * fallForce);
            }
            else
            {
                rb.useGravity = true;
                animator.SetBool("IsGlinding", false);
            }
        }*/ //IS WORKING JUST FINNE
}

