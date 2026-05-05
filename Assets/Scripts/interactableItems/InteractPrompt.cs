using TMPro;
using UnityEngine;

public class InteractPrompt : MonoBehaviour
{
    private TMP_Text text;
    public string prompt; // this is where you will write what the prompt is for ex: interact, place gem, etc.
    public GameObject player;
    [SerializeField] private bool r_to_prompt = true;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        if (text != null && r_to_prompt)
        {
            text.text = $"R to {prompt}";
        }
        else if (text != null)
        {
            text.text = $"{prompt}";
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (text != null)
        {
            if (other.gameObject == player)
            {
                text.enabled = true;
                Debug.Log("interact prompt should be present");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (text != null)
        {
            if (other.gameObject == player)
            {
                text.enabled = false;
                Debug.Log("interact prompt should be absent");
            }
        }
    }

    void LateUpdate()
    {
        // Makes the text rotation match the camera's location
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;

        transform.rotation = Quaternion.LookRotation(forward);
    }
}
