using UnityEngine;

public class CameraSwitchExit : MonoBehaviour
{
    [SerializeField] private GameObject freeLookCamera;
    [SerializeField] private GameObject mixedCamera;
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            freeLookCamera.SetActive(true);
            mixedCamera.SetActive(false);
        }
    }
    
}
