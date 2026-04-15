using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject freeLookCamera;
    [SerializeField] private GameObject mixedCamera;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            freeLookCamera.SetActive(false);
            mixedCamera.SetActive(true);
        }
    }
    
}
