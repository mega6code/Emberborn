using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] Animator animator;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    private Vector2 rotateStartVector = new Vector2(0, 1);
    private bool isGrounded = false;

    //[SerializeField] private float glindDuration= 15f;
    
    private bool isGlinding= false;
    private bool hadGlinded= false;

    [SerializeField] private float fallForce = 0.1f;


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
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsFalling", false);

            return;
        }

        if (isGrounded && input != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsFalling", false);

            // ROTATION
            float angle = Vector2.SignedAngle(rotateStartVector, input); //this is storing an agle in a variable
            rb.MoveRotation(Quaternion.Euler(0, -angle, 0)); //this is rotating he rb around that angle

            // MOVEMENT
            Vector3 moveDir = transform.forward * moveSpeed; //this is creatin direction that will always be the forwad
            rb.linearVelocity = new Vector3(moveDir.x, rb.linearVelocity.y, moveDir.z); //this is saying, the velocity will be the

        }

        //if(!isGrounded)
    }


    public void OnJump()
    {

        if (!isGrounded)
        {
            animator.SetBool("IsFalling", true);
            Debug.Log("is falling");
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
            //rb.useGravity = false;
            animator.SetBool("IsGlinding", true);
            animator.SetBool("IsFalling", false);

            fallForce += fallForce * Time.deltaTime;
            rb.AddForce(Vector3.down * fallForce);
        }
        else
        {
            rb.useGravity = true;
            animator.SetBool("IsGlinding", false);
        }
    }

    /*public void OnGlind(bool glideHeld)
    {
        // Glide only while button is held
        isGlinding = glideHeld;
        if (hadGlinded == true)
        {
            isGrounded = true;
            return;
        }

        if (isGrounded == true)
        {
            hadGlinded = false;
            isGlinding = false;
            rb.useGravity = true;
        }

        if (isGlinding == true)
        {
            isGrounded = false;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsGlinding", true);

            //call the method of turning of the gravity
            hadGlinded = true;
        }
    }

    public void TurnOffGravity(float amtOfSeconds)
    {
        //turn off the gravity for certain amout of time
        rb.useGravity = false;

        //wait a certain amt of time...

        //turn on the gravity again
        rb.useGravity = true;

    }*/

}

