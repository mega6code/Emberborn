using UnityEngine;

public class Fake_platforms : MonoBehaviour
{
    [SerializeField] private Animation platformAnim;
    [SerializeField] private Rigidbody platformRB;
    [SerializeField] private GameObject platform;

    private Vector3 initialPosition;

    private void Start()
    {
        platformAnim = GetComponent<Animation>();
        platformRB = GetComponent<Rigidbody>();
        platformRB.useGravity = false;
        platform.SetActive(true);
        initialPosition = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (platformAnim != null && platformRB != null)
        {
            platformAnim.Play();

            platformRB.useGravity = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            platform.SetActive(false);
            /*platformRB.linearVelocity = Vector3.zero;
            platformRB.angularVelocity = Vector3.zero;
            transform.position = initialPosition;
            platformRB.useGravity = false;*/
        }
    }
}
